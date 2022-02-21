using LexiconMVC_ViewModels.Models;
using LexiconMVC_ViewModels.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Controllers
{
    public class CityController : Controller
    {
        private ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.City.ToList());
        }

        

        // GET: CityController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                _context.City.Add(city);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: CityController/Details/5
        public IActionResult Details(string CityName)
        {

            return View("Details", _context.City.Find(CityName));

        }


        public ActionResult Delete(string CityName)
        {
            var cityToDelete = _context.City.FirstOrDefault(x => x.CityName == CityName);
            _context.City.Remove(cityToDelete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "City");
        }
    }
}
