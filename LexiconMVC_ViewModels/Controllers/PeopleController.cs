using LexiconMVC_ViewModels.Models.Data;
using LexiconMVC_ViewModels.Models;
using LexiconMVC_ViewModels.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            return View(_context.People.Include(c => c.City).Where(c => c.CurrentCityId == c.City.CityId).ToList()); 
        }

        // GET: PeopleController/Create
        [HttpGet]
        public ActionResult Create()
        {
            CreatePersonViewModel model = new CreatePersonViewModel();
            model.Cities = _context.City.ToList();
            return View(model);
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePersonViewModel createPerson)
        {   
           
            if (ModelState.IsValid)
            {
                Person person = new Person()
                {
                    Name = createPerson.Name,
                    CurrentCityId = createPerson.CurrentCityId,
                    PhoneNumber = createPerson.PhoneNumber
                };
                _context.People.Add(person);
                _context.SaveChanges();

            }
            
            return RedirectToAction("Index");
        }

        //private void PopulateCityDropDownList(City selectedCity = null)
        //{
        //    var citiesQuery = from c in _context.City
        //                           orderby c.CityName
        //                           select c;
        //    ViewData["CurrentCityId"] = new SelectList(citiesQuery, "CitId", "CityName", selectedCity);
        //}

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

        public ActionResult Delete(int id)
        {
            var personToDelete = _context.People.FirstOrDefault(x => x.Id == id);
            _context.People.Remove(personToDelete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "People");
        }

        
        public async Task<IActionResult> Search(string text)
        {
            var persons = from p in _context.People
                         select p;

            if (!String.IsNullOrEmpty(text))
            {
                persons = persons.Where(s => s.Name!.Contains(text));
            }

            return View("Index", await persons.ToListAsync());
        }        
    }
    }
