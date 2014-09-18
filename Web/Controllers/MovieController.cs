using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using MovieSearch.Data.Models;
using MovieSearch.Logic.Contracts;
using MovieSearch.Logic.Contracts.Services;
using MovieSearch.Web.Models;
using Newtonsoft.Json;
using PagedList;

namespace MovieSearch.Web.Controllers
{
    [HandleError]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICountryService _countryService;
        private readonly IPeopleService _peopleService;
        private readonly IGenreService _genreService;
        private readonly ICareerService _careerService;
        private readonly IUserCommentService _userCommentService;
        private readonly IRatingService _ratingService;

        public MovieController(IMovieService movieService, ICountryService countryService,
                               IGenreService genreService, IPeopleService peopleService,
                               ICareerService careerService, IUserCommentService userCommentService,
                               IRatingService ratingService)
        {
            _movieService = movieService;
            _countryService = countryService;
            _genreService = genreService;
            _peopleService = peopleService;
            _careerService = careerService;
            _userCommentService = userCommentService;
            _ratingService = ratingService;
        }

        // GET: /Movie/
        public ActionResult Index(string movieTitle, string genreTitle, string sortOrder,
                                  string currentTitle, string currentGenre, int? page)
        {
            var movies = _movieService.GetAll();
            var genres = _genreService.GetAll();

            if (movieTitle != null || genreTitle != null)
            {
                page = 1;
            }
            else
            {
                movieTitle = currentTitle;
                genreTitle = currentGenre;
            }
            ViewBag.CurrentTitle = movieTitle;
            ViewBag.genreTitle = new SelectList(genres, "Title", "Title");
            ViewBag.CurrentGenre = genreTitle;
            
            var movieViewModel = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies);
            FilterByTitleOrGenre(movieTitle, genreTitle, ref movieViewModel);

            foreach (var movie in movieViewModel)
            {
                movie.Rating = _ratingService.CountRatingByMovieId(movie.Id);
            }

            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.RateSortParm = sortOrder == "Rate" ? "rate_desc" : "Rate";
            SortMovies(sortOrder, ref movieViewModel);

            const int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(movieViewModel.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Rate(FormCollection data)
        {
            var rating = new Rating
            {
                MovieId = new Guid(data["id"]),
                UserId = User.Identity.GetUserId(),
                ValueOfRating = Convert.ToDouble(data["rate"])
            };
            var movie = _movieService.GetMovieById(new Guid(data["id"]));
            if (movie.Ratings.Count(m => m.MovieId == movie.Id 
                                    && m.UserId == User.Identity.GetUserId()) == 0)
            {
                _ratingService.AddRating(rating);
            }
            _ratingService.Edit(rating);
            var s = _ratingService.CountRatingByMovieId(rating.MovieId);
            ViewBag.Rating = s;
            return PartialView();
        }

        [HttpPost]
        [Authorize]
        public ActionResult VoteAgain(Guid movieId)
        {
            _ratingService.DeleteByMovieIdAndUserId(movieId, User.Identity.GetUserId());
            return RedirectToAction("Details", new { id = movieId });
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(Guid movieId, string comment)
        {
            var userComment = new UserComment
            {
                Id = Guid.NewGuid(),
                Comment = comment,
                Date = DateTime.Now,
                MovieId = movieId,
                UserId = User.Identity.GetUserId()
            };
            _userCommentService.AddUserComment(userComment);
            if (Request.IsAjaxRequest())
            {
                ViewBag.UserName = User.Identity.Name;
                ViewBag.Date = userComment.Date;
                ViewBag.Comment = userComment.Comment;
                return PartialView();
            }
            return RedirectToAction("Details", new {id = movieId});
        }

        // GET: /Movie/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _movieService.GetMovieById(id);
            MovieViewModel movieViewModel = Mapper.Map<Movie, MovieViewModel>(movie);

            GetImdbRating(movieViewModel);
            movieViewModel.Rating = _ratingService.CountRatingByMovieId(movieViewModel.Id);
            if (Request.IsAjaxRequest())
            {
                return PartialView("MovieDetailsParital", movieViewModel);
            }
            return View(movieViewModel);
        }

        // GET: /Movie/CreateOrUpdate
        [Authorize(Roles = "Admin")]
        public ActionResult CreateOrUpdate(Guid? id)
        {
            bool isCreate = !id.HasValue;
            MovieViewModel movieViewModel;
            if (isCreate)
            {
                movieViewModel = new MovieViewModel { PremiereDate = null };
            }
            else
            {
                var movie = _movieService.GetMovieById(id);
                movieViewModel = Mapper.Map<Movie, MovieViewModel>(movie);
                movieViewModel.DirectorId = _peopleService.GetDirectorIdForMovie(movie);
            }

            var countries = _countryService.GetAll();
            var directors = _peopleService.GetAll();

            movieViewModel.ActorsList = GetActorsList(movieViewModel);
            movieViewModel.GenreList = GetGenreList(movieViewModel);
            movieViewModel.Directors = new SelectList(directors, "Id", "FullName");
            movieViewModel.Countries = new SelectList(countries, "Id", "Title");

            return View(movieViewModel);
        }

        // POST: /Movie/CreateOrUpdate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateOrUpdate(
            [Bind(Include = "Id,Title,PremiereDate,Desctiption,CountryId,DirectorId,ImdbId,TrailerLink")] MovieViewModel movieViewModel,
            HttpPostedFileBase file, string[] selectedGenres, string[] selectedActors)
        {
            bool isCreate = false;
            if (ModelState.IsValid)
            {
                if (movieViewModel.Id == new Guid())
                {
                    movieViewModel.Id = Guid.NewGuid();
                    isCreate = true;
                }

                SaveImage(movieViewModel, file);
                CreateOfUpdateActorsInMovie(selectedActors, movieViewModel);
                CreateOfUpdateGenresOfMovie(selectedGenres, movieViewModel);
                AddDirector(movieViewModel);
                movieViewModel.TrailerLink += "&autoplay=1";
                Movie movie = Mapper.Map<MovieViewModel, Movie>(movieViewModel);
                if (isCreate)
                {
                    _movieService.AddMovie(movie);
                }
                else
                {
                    _movieService.Edit(movie);
                }
                
                return RedirectToAction("Index");
            }
            
            return View(movieViewModel);
        }

        // GET: /Movie/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _movieService.GetMovieById(id);
            MovieViewModel viewModelList = Mapper.Map<Movie, MovieViewModel>(movie);
            return View(viewModelList);
        }

        // POST: /Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Movie movie = _movieService.GetMovieById(id);
            _movieService.Delete(movie.Id);
            DeletePoster(movie);
            return RedirectToAction("Index");
        }

        //For Edit and Create Actors (GET)
        private List<ActorsInMovieViewModel> GetActorsList(MovieViewModel movieViewModel)
        {
            if (movieViewModel.CastAndCrews == null)
            {
                movieViewModel.CastAndCrews = new List<CastAndCrew>();
            }

            var allActors = _peopleService.GetAll();
            var actorsInMovie = new HashSet<Guid>(movieViewModel.CastAndCrews.Select(c => c.PeopleId));
            var actorsList = new List<ActorsInMovieViewModel>();
            foreach (var actor in allActors)
            {
                actorsList.Add(new ActorsInMovieViewModel
                {
                    ActorId = actor.Id,
                    FullName = actor.FullName,
                    Choosen = actorsInMovie.Contains(actor.Id)
                });
            }
            return actorsList;
        }

        //For Edit and Create Actors (POST)
        private void CreateOfUpdateActorsInMovie(string[] selectedActors, MovieViewModel movieViewModel)
        {
            if (selectedActors == null)
            {
                movieViewModel.CastAndCrews = new List<CastAndCrew>();
                return;
            }

            if (movieViewModel.CastAndCrews == null)
            {
                movieViewModel.CastAndCrews = new List<CastAndCrew>();
            }

            var selectedActorsHs = new HashSet<string>(selectedActors);
            var actorsInMovie = new HashSet<Guid>(movieViewModel.CastAndCrews.Select(c => c.PeopleId));
            foreach (var actor in _peopleService.GetAll())
            {
                var addActor = new CastAndCrew
                {
                    MovieId = movieViewModel.Id,
                    PeopleId = actor.Id,
                    CareerId = _careerService.GetCareerByTitle("Actor").Id
                };
                if (selectedActorsHs.Contains(actor.Id.ToString()))
                {
                    if (!actorsInMovie.Contains(actor.Id))
                    {
                        movieViewModel.CastAndCrews.Add(addActor);
                    }
                }
                else
                {
                    if (actorsInMovie.Contains(actor.Id))
                    {
                        movieViewModel.CastAndCrews.Remove(addActor);
                    }
                }
            } 
        }

        //For Edit and Create Genres (GET)
        private List<GenresOfMovieViewModel> GetGenreList(MovieViewModel movieViewModel)
        {
            if (movieViewModel.Genres == null)
            {
                movieViewModel.Genres = new List<Genre>();
            }

            var allGenres = _genreService.GetAll();
            var genresOfMovie = new HashSet<Guid>(movieViewModel.Genres.Select(c => c.Id));
            var genreList = new List<GenresOfMovieViewModel>();
            foreach (var genre in allGenres)
            {
                genreList.Add(new GenresOfMovieViewModel
                {
                    GenreId = genre.Id,
                    Title = genre.Title,
                    Choosen = genresOfMovie.Contains(genre.Id)
                });
            }
            return genreList;
        }

        //For Edit and Create Genres (POST)
        private void CreateOfUpdateGenresOfMovie(string[] selectedGenres, MovieViewModel movieViewModel)
        {
            if (selectedGenres == null)
            {
                movieViewModel.Genres = new List<Genre>();
                return;
            }

            if (movieViewModel.Genres == null)
            {
                movieViewModel.Genres = new List<Genre>();
            }

            var selectedGenresHs = new HashSet<string>(selectedGenres);
            var genresOfMovie = new HashSet<Guid>(movieViewModel.Genres.Select(c => c.Id));
            foreach (var genre in _genreService.GetAll())
            {
                if (selectedGenresHs.Contains(genre.Id.ToString()))
                {
                    if (!genresOfMovie.Contains(genre.Id))
                    {
                        movieViewModel.Genres.Add(genre);
                    }
                }
                else
                {
                    if (genresOfMovie.Contains(genre.Id))
                    {
                        movieViewModel.Genres.Remove(genre);
                    }
                }
            } 
        }

        private void AddDirector(MovieViewModel movieViewModel)
        {
            movieViewModel.CastAndCrews.Add(new CastAndCrew
            {
                MovieId = movieViewModel.Id,
                PeopleId = movieViewModel.DirectorId,
                CareerId = _careerService.GetCareerByTitle("Director").Id
            });
        }

        private void GetImdbRating(MovieViewModel movieViewModel)
        {
            string url = String.Format("http://www.omdbapi.com/?i={0}", movieViewModel.ImdbId);
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            string jsonResponse = "";
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                jsonResponse = streamReader.ReadToEnd();
            }

            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);
            if (String.Equals(values["Response"], "True", StringComparison.OrdinalIgnoreCase))
            {
                movieViewModel.ImdbRating = values["imdbRating"];
            }
            else
            {
                movieViewModel.ImdbRating = "Movie not found on Imdb";
            }
        }

        private void SaveImage(MovieViewModel movieViewModel, HttpPostedFileBase file)
        {
            if (file != null)
            {
                file.SaveAs(HttpContext.Server.MapPath("~/Posters/") + movieViewModel.Id + ".jpg");
            }
        }

        private void DeletePoster(Movie movie)
        {
            var myfileinfo = new FileInfo(HttpContext.Server.MapPath("~/Posters/") + movie.Id + ".jpg");
            myfileinfo.Delete();
        }

        private void FilterByTitleOrGenre(string movieTitle, string genreTitle, ref IEnumerable<MovieViewModel> movieViewModel)
        {
            if (!String.IsNullOrEmpty(movieTitle))
            {
                movieViewModel = movieViewModel.Where(m => m.Title.Contains(movieTitle));
                    // String.Equals(m.Title, movieTitle, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(genreTitle))
            {
                movieViewModel = movieViewModel.Where(m => m.Genres.Any(
                                      g => String.Equals(g.Title, genreTitle, StringComparison.OrdinalIgnoreCase)));
            }
        }

        private void SortMovies(string sortOrder, ref IEnumerable<MovieViewModel> movieViewModel)
        {
            switch (sortOrder)
            {
                case "title_desc":
                    movieViewModel = movieViewModel.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    movieViewModel = movieViewModel.OrderBy(s => s.PremiereDate);
                    break;
                case "date_desc":
                    movieViewModel = movieViewModel.OrderByDescending(s => s.PremiereDate);
                    break;
                case "rate_desc":
                    movieViewModel = movieViewModel.OrderByDescending(s => s.Rating);
                    break;
                case "Rate":
                    movieViewModel = movieViewModel.OrderBy(s => s.Rating);
                    break;
                default: // Title ascending 
                    movieViewModel = movieViewModel.OrderBy(s => s.Title);
                    break;
            }
        }
    }
}
