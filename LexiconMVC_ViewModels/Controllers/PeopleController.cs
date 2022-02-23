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
            model.Cities = _context.Cities.ToList();
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

        
        // GET: PeopleController/Details/5
        public IActionResult Details(int id)
        {                     
            return View("Details", _context.People.Find(id));
        }

        // GET: PeopleController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
           Person person = _context.People.FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            CreatePersonViewModel editPerson = new CreatePersonViewModel()
            {
                Name = person.Name,
                CurrentCityId = person.CurrentCityId,
                PhoneNumber = person.PhoneNumber,
            };
            editPerson.Cities = _context.Cities.ToList();

            ViewBag.Id = id;

            return View(editPerson);
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreatePersonViewModel personToEdit)
        {
            Person person = _context.People.FirstOrDefault(x => x.Id == id);
            if (ModelState.IsValid)
            {
                person.Name = personToEdit.Name;
                person.CurrentCityId = personToEdit.CurrentCityId;
                person.PhoneNumber = personToEdit.PhoneNumber;

                _context.Entry(person).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            personToEdit.Cities = _context.Cities.ToList();
            ViewBag.Id = id;

            return View(personToEdit);            
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

            persons = persons.Include(c => c.City).Where(c => c.CurrentCityId == c.City.CityId);

            if (!String.IsNullOrEmpty(text))
            {
                persons = persons.Where(s => s.Name!.Contains(text));
            }

            return View("Index", await persons.ToListAsync());
        }        
    }
    }
