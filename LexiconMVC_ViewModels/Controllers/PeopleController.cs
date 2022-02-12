using LexiconMVC_ViewModels.Models.Entitys;
using LexiconMVC_ViewModels.Models.Services;
using LexiconMVC_ViewModels.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LexiconMVC_ViewModels.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonDataService _personDataService;

        public PeopleController()
        {
            _personDataService = new PersonDataService();
        }

        // GET: PeopleController
        public ActionResult Index()
        {
            return View(_personDataService.GetList());
        }

        // GET: PeopleController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePersonViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                PersonData personData = _personDataService.Add(createViewModel);

                if (personData != null)
                {
                    return RedirectToAction(nameof(Index), "People");
                }

                ModelState.AddModelError("Storage", "Failed to save");
            }

            return View(createViewModel);
        }

        // GET: PeopleController/Details/5
        public ActionResult Details(int id)
        {
            PersonData personData = _personDataService.GetById(id);

            if (personData == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(personData);
        }

        // GET: PeopleController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreatePersonViewModel createViewModel)
        {            
                PersonData personData = _personDataService.Edit(id, createViewModel);

                if (personData == null)
                {
                    return RedirectToAction(nameof(Index), "People");
                }           

            return View(personData);
        }

        // GET: PeopleController/Delete/5
        [HttpGet]
        public JsonResult Delete(string id)
        {
            string result = "Not found test";
            return Json(result);
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Delete(string id, bool confirm)
        {

            string result = string.Format("Ajax call made at {0}", DateTime.Now + id);
           
            return Json(result);
        }

        //PartialView Actions
        [HttpGet]
        public IActionResult People()
        {
            List<PersonData> personData = _personDataService.GetList();
            PeopleViewModel people;

            List<PeopleViewModel> listOfPeople = new List<PeopleViewModel>(); 

            if(personData !=null)
            {
                foreach (PersonData item in personData)
                {
                    people = new PeopleViewModel();

                    people.Id = item.Id;
                    people.Name = item.Name;
                    people.City = item.City;
                    listOfPeople.Add(people);
                }
                return PartialView("_People", listOfPeople);
            }

            return PartialView("_People");

        }

        // GET: PeopleController/Search
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        // GET: PeopleController/Search
        [HttpPost]
        public ActionResult Search(string text)
        {
            List<PersonData> searchResult = _personDataService.Search(text);


            if (searchResult == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(searchResult);

        }
    }
}
