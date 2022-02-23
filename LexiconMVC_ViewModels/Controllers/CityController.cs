using LexiconMVC_ViewModels.Models;
using LexiconMVC_ViewModels.Models.Data;
using LexiconMVC_ViewModels.Models.ViewModels;
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
            return View(_context.Cities.ToList());
        }

        

        // GET: CityController/Create
        [HttpGet]
        public ActionResult Create()
        {
            CreateCityViewModel model = new CreateCityViewModel();
           
            return View(model);
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCityViewModel createCity)
        {
            if (ModelState.IsValid)
            {
                City city = new City()
                {
                    CityName = createCity.CityName
                };
                _context.Cities.Add(city);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index), "City");
        }

        // GET: CityController/Details/5
        public IActionResult Details(string CityName)
        {

            return View("Details", _context.Cities.Find(CityName));

        }


        public ActionResult Delete(string CityName)
        {
            var cityToDelete = _context.Cities.FirstOrDefault(x => x.CityName == CityName);
            _context.Cities.Remove(cityToDelete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "City");
        }
    }
}
