using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MovieSearch.Data.Models;

namespace MovieSearch.Web.Models
{
    public class MovieViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name = "Title")]
        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Premiere Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? PremiereDate { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Desctiption { get; set; }

        [Display(Name = "Country")]
        [Required]
        public Guid CountryId { get; set; }

        public Country Country { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        [Display(Name = "Genres")]
        public ICollection<Genre> Genres { get; set; }
        public List<GenresOfMovieViewModel> GenreList { get; set; }

        [Display(Name = "Actors")]
        public ICollection<CastAndCrew> CastAndCrews { get; set; }
        public List<ActorsInMovieViewModel> ActorsList { get; set; }

        [Display(Name = "Director")]
        public Guid DirectorId { get; set; }
        public IEnumerable<SelectListItem> Directors { get; set; }

        [Display(Name = "Comments")]
        public ICollection<UserComment> UserComments { get; set; }

        [Display(Name = "Rating")]
        public double Rating { get; set; }
        public ICollection<Rating> Ratings { get; set; }

        [Display(Name = "IMDb Rating")]
        public string ImdbRating { get; set; }
        public string ImdbId { get; set; }

        [Display(Name = "Trailer")]
        public string TrailerLink { get; set; }
    }
}