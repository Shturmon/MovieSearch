using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using BLL.Contracts;
using DAL.Models;
using Web.Models;

namespace Web.Controllers
{
    [HandleError]
    public class GenreController : Controller
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService service)
        {
            _service = service;
        }

        // GET: /Genre/
        public ActionResult Index()
        {
            IEnumerable<Genre> genres = _service.GetAll();
            return View(Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>(genres));
        }

        // GET: /Genre/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = _service.GetGenreById(id);
            GenreViewModel viewModelList = Mapper.Map<Genre, GenreViewModel>(genre);
            return View(viewModelList);
        }

        // GET: /Genre/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Genre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Title")] GenreViewModel genreViewModel)
        {
            if (ModelState.IsValid)
            {
                genreViewModel.Id = Guid.NewGuid();
                Genre genre = Mapper.Map<GenreViewModel, Genre>(genreViewModel);
                _service.AddGenre(genre);
                return RedirectToAction("Index");
            }

            return View(genreViewModel);
        }

        // GET: /Genre/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = _service.GetGenreById(id);
            GenreViewModel viewModelList = Mapper.Map<Genre, GenreViewModel>(genre);
            return View(viewModelList);
        }

        // POST: /Genre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Title")] GenreViewModel genreViewModel)
        {
            if (ModelState.IsValid)
            {
                Genre genre = Mapper.Map<GenreViewModel, Genre>(genreViewModel);
                _service.Edit(genre);
                return RedirectToAction("Index");
            }
            return View(genreViewModel);
        }

        // GET: /Genre/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = _service.GetGenreById(id);
            GenreViewModel viewModelList = Mapper.Map<Genre, GenreViewModel>(genre);
            return View(viewModelList);
        }

        // POST: /Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Genre genre = _service.GetGenreById(id);
            _service.Delete(genre.Id);
            return RedirectToAction("Index");
        }
    }
}
