﻿using LexiconMVC_ViewModels.Models.Entitys;
using LexiconMVC_ViewModels.Models.Services;
using LexiconMVC_ViewModels.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            if (ModelState.IsValid)
            {
                PersonData personData = _personDataService.Edit(id, createViewModel);

                if (personData == null)
                {
                    return RedirectToAction(nameof(Index), "People");
                }
                return View(personData);
            }

            return View();
        }

        // GET: PeopleController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool confirm)
        {
            confirm = _personDataService.Delete(id);
            if (!confirm)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        //PartialView Actions
        [HttpGet]
        public IActionResult Last()
        {
            List<PersonData> personData = _personDataService.GetList();
            PersonData lastInfo = new PersonData();

            foreach (PersonData item in personData)
            {
                if (item.Id > lastInfo.Id)
                {
                    lastInfo = item;
                }
            }

            return PartialView("_personData", lastInfo);
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
