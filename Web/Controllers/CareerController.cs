using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using MovieSearch.Data.Models;
using MovieSearch.Logic.Contracts;
using MovieSearch.Logic.Contracts.Services;
using MovieSearch.Web.Models;

namespace MovieSearch.Web.Controllers
{
    public class CareerController : Controller
    {
        private ICareerService _service;

        public CareerController(ICareerService service)
        {
            _service = service;
        }

        // GET: /Career/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            IEnumerable<Career> careers = _service.GetAll();
            return View(Mapper.Map<IEnumerable<Career>, IEnumerable<CareerViewModel>>(careers));
        }

        // GET: /Career/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = _service.GetCareerById(id);
            CareerViewModel viewModelList = Mapper.Map<Career, CareerViewModel>(career);
            return View(viewModelList);
        }

        // GET: /Career/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Career/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include="Id,Title")] CareerViewModel careerViewModel)
        {
            if (ModelState.IsValid)
            {
                careerViewModel.Id = Guid.NewGuid();
                Career career = Mapper.Map<CareerViewModel, Career>(careerViewModel);
                _service.AddCareer(career);
                return RedirectToAction("Index");
            }

            return View(careerViewModel);
        }

        // GET: /Career/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = _service.GetCareerById(id);
            CareerViewModel viewModelList = Mapper.Map<Career, CareerViewModel>(career);
            return View(viewModelList);
        }

        // POST: /Career/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include="Id,Title")] CareerViewModel careerViewModel)
        {
            if (ModelState.IsValid)
            {
                Career career = Mapper.Map<CareerViewModel, Career>(careerViewModel);
                _service.Edit(career);
                return RedirectToAction("Index");
            }
            return View(careerViewModel);
        }

        // GET: /Career/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = _service.GetCareerById(id);
            CareerViewModel viewModelList = Mapper.Map<Career, CareerViewModel>(career);
            return View(viewModelList);
        }

        // POST: /Career/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Career career = _service.GetCareerById(id);
            _service.Delete(career.Id);
            return RedirectToAction("Index");
        }
    }
}
