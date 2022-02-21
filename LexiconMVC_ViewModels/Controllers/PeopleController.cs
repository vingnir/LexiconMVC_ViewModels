using LexiconMVC_ViewModels.Models.Repo;
using LexiconMVC_ViewModels.Models;
using LexiconMVC_ViewModels.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVC_ViewModels.Controllers
{
    public class PeopleController : Controller
    {
       
        private ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PeopleController
        public ActionResult Index()
        {
            return View(_context.People.ToList()); 
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
        public ActionResult Create(Person person)
        {   
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        // GET: PeopleController/Details/5
        public IActionResult Details(int id)
        {
                       
            return View("Details", _context.People.Find(id));

        }

        // GET: PeopleController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_context.People.FirstOrDefault(x => x.Id == id)); 
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person personToEdit)
        {
                                   
            _context.Entry(personToEdit).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "People");
        }



        // POST: PeopleController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var personToDelete = _context.People.FirstOrDefault(x => x.Id == id);
            _context.People.Remove(personToDelete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "People");
        }

        ////PartialView Actions

        //// GET: PeopleController/Search
        //[HttpGet]
        //public ActionResult Search()
        //{
        //    return View("Index");
        //}

        //// GET: PeopleController/Search
        //[HttpPost]
        //public ActionResult Search(string text)
        //{
        //    List<PersonData> searchResult = _personDataService.Search(text);


        //    if (searchResult == null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View("Index",searchResult);

        //}

        //public IActionResult IndexPartial()
        //{
        //    List<PersonData> personData = _personDataService.GetList();
        //    PeopleViewModel people;

        //    List<PeopleViewModel> listOfPeople = new List<PeopleViewModel>();

        //    if (personData != null)
        //    {
        //        foreach (PersonData item in personData)
        //        {
        //            people = new PeopleViewModel();

        //            people.Id = item.Id;
        //            people.Name = item.Name;
        //            people.City = item.City;
        //            people.PhoneNumber = item.PhoneNumber;
        //            listOfPeople.Add(people);
        //        }

        //    }


        //    return View(listOfPeople);
        //}
    }
}
