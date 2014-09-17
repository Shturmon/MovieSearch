using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using BLL.Contracts;
using DAL.Models;
using PagedList;
using Web.Models;

namespace Web.Controllers
{
    [HandleError]
    public class PeopleController : Controller
    {
        private readonly IPeopleService _service;

        public PeopleController(IPeopleService service)
        {
            _service = service;
        }

        // GET: /People/
        public ActionResult Index(string fullName, string currentFullName, int? page)
        {
            var peoples = _service.GetAll();

            if (fullName != null)
            {
                page = 1;
            }
            else
            {
                fullName = currentFullName;
            }
            ViewBag.CurrentFullName = fullName;

            var peopleViewModel = Mapper.Map<IEnumerable<People>, IEnumerable<PeopleViewModel>>(peoples);
            FilterByName(fullName, ref peopleViewModel);

            const int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(peopleViewModel.ToPagedList(pageNumber, pageSize));
        }

        // GET: /People/Details/5
        public ActionResult Details(Guid? id)
        {
             if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People people = _service.GetPeopleById(id);
            PeopleViewModel peopleViewModel = Mapper.Map<People, PeopleViewModel>(people);
            if (Request.IsAjaxRequest())
            {
                return PartialView(peopleViewModel);
            }
            return View(peopleViewModel);
        }

        // GET: /People/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include="Id,FirstName,LastName,BirthDay,BirthPlace")] PeopleViewModel peopleViewModel)
        {
            if (ModelState.IsValid)
            {
                peopleViewModel.Id = Guid.NewGuid();
                People people = Mapper.Map<PeopleViewModel, People>(peopleViewModel);
                _service.AddPeople(people);
                return RedirectToAction("Index");
            }

            return View(peopleViewModel);
        }

        // GET: /People/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid? id)
        {
           if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People people = _service.GetPeopleById(id);
            PeopleViewModel peopleViewModel = Mapper.Map<People, PeopleViewModel>(people);
            return View(peopleViewModel);
        }

        // POST: /People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include="Id,FirstName,LastName,BirthDay,BirthPlace")] PeopleViewModel peopleViewModel)
        {
            if (ModelState.IsValid)
            {
                People people = Mapper.Map<PeopleViewModel, People>(peopleViewModel);
                _service.Edit(people);
                return RedirectToAction("Index");
            }
            return View(peopleViewModel);
        }

        // GET: /People/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid? id)
        {
           if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People people = _service.GetPeopleById(id);
            PeopleViewModel peopleViewModel = Mapper.Map<People, PeopleViewModel>(people);
            return View(peopleViewModel);
        }

        // POST: /People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            People people = _service.GetPeopleById(id);
            _service.Delete(people.Id);
            return RedirectToAction("Index");
        }

        private void FilterByName(string fullName, ref IEnumerable<PeopleViewModel> peopleViewModel)
        {
            if (!String.IsNullOrEmpty(fullName))
            {
                peopleViewModel = peopleViewModel.Where(
                    m => String.Equals(m.FullName, fullName, StringComparison.OrdinalIgnoreCase)
                      || String.Equals(m.FirstName, fullName, StringComparison.OrdinalIgnoreCase)
                      || String.Equals(m.LastName, fullName, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
