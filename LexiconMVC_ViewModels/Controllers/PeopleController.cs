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
        public ActionResult Create(string name, string city, string phone)
        {
            CreatePersonViewModel createViewModel = new CreatePersonViewModel();
            createViewModel.Name = name;
            createViewModel.City = city;
            createViewModel.PhoneNumber = phone;
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
        public IActionResult Details(int id)
        {
            PersonData personData = _personDataService.GetById(id);

            if (personData == null)
            {
                return PartialView("_Details");
            }
            return PartialView("_Details", personData);
           
        }

        // GET: PeopleController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PersonData personData = _personDataService.GetById(id);
            if (personData == null)
            {
                return RedirectToAction(nameof(Index), "People");
            }
            return View(personData);
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
        public IActionResult Delete(int id)
        {
            PersonData personData = _personDataService.GetById(id);
            if (personData == null)
            {
                return RedirectToAction(nameof(Index), "People");
            }
            return View("Delete", personData);
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool confirm)
        {
            confirm = _personDataService.Delete(id);
            if (confirm)
            {
                return RedirectToAction(nameof(Index), "People");
                //return View("Index");
            }


            return View("Create");
        }

        //PartialView Actions
        
        // GET: PeopleController/Search
        [HttpGet]
        public ActionResult Search()
        {
            return View("Index");
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
            return View("Index",searchResult);

        }

        public IActionResult IndexPartial()
        {
            List<PersonData> personData = _personDataService.GetList();
            PeopleViewModel people;

            List<PeopleViewModel> listOfPeople = new List<PeopleViewModel>();

            if (personData != null)
            {
                foreach (PersonData item in personData)
                {
                    people = new PeopleViewModel();

                    people.Id = item.Id;
                    people.Name = item.Name;
                    people.City = item.City;
                    people.PhoneNumber = item.PhoneNumber;
                    listOfPeople.Add(people);
                }
                
            }

           
            return View(listOfPeople);
        }
    }
}
