using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using DAL.Models;
using Web.Models;
using BLL.Contracts;

namespace Web.Controllers
{
    [HandleError]
    public class CountryController : Controller
    {
        private ICountryService _service;

        public CountryController(ICountryService service)
        {
            _service = service;
        }

        // GET: /Country/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            IEnumerable<Country> countries = _service.GetAll();
            return View(Mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(countries));
        }

        // GET: /Country/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = _service.GetCountryById(id);
            CountryViewModel viewModelList = Mapper.Map<Country, CountryViewModel>(country);
            return View(viewModelList);
        }

        // GET: /Country/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Country/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include="Id,Title")] CountryViewModel countryViewModel)
        {
            if (ModelState.IsValid)
            {
                countryViewModel.Id = Guid.NewGuid();
                Country country = Mapper.Map<CountryViewModel, Country>(countryViewModel);
                _service.AddCountry(country);
                return RedirectToAction("Index");
            }

            return View(countryViewModel);
        }

        // GET: /Country/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = _service.GetCountryById(id);
            CountryViewModel viewModelList = Mapper.Map<Country, CountryViewModel>(country);
            return View(viewModelList);
        }

        // POST: /Country/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include="Id,Title")] CountryViewModel countryViewModel)
        {
            if (ModelState.IsValid)
            {
                Country country = Mapper.Map<CountryViewModel, Country>(countryViewModel);
                _service.Edit(country);
                return RedirectToAction("Index");
            }
            return View(countryViewModel);
        }

        // GET: /Country/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = _service.GetCountryById(id);
            CountryViewModel viewModelList = Mapper.Map<Country, CountryViewModel>(country);
            return View(viewModelList);
        }

        // POST: /Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Country country = _service.GetCountryById(id);
            _service.Delete(country.Id);
            return RedirectToAction("Index");
        }
    }
}
