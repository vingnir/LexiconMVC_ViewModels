using LexiconMVC_ViewModels.Models;
using LexiconMVC_ViewModels.Models.Data;
using LexiconMVC_ViewModels.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Controllers
{
    public class CountryController : Controller
    {
        private ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Countries.ToList());
        }

        // GET: CountryController/Create
        [HttpGet]
        public ActionResult Create()
        {
            CreateCountryViewModel model = new CreateCountryViewModel();
           
            return View(model);
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCountryViewModel createCountry)
        {
            if (ModelState.IsValid)
            {
                Country country = new Country()
                {
                    CountryName = createCountry.CountryName
                };
                _context.Countries.Add(country);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: CountryController/Details/5
        public IActionResult Details(string countryName)
        {

            return View("Details", _context.Countries.Find(countryName));

        }

        
        public ActionResult Delete(int id)
        {
            var countryToDelete = _context.Countries.FirstOrDefault(x => x.CountryId == id);
            _context.Countries.Remove(countryToDelete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Country");
        }


        //public async Task<IActionResult> Search(string text)
        //{
        //    var country = from c in _context.Country
        //                  select c;

        //    if (!String.IsNullOrEmpty(text))
        //    {
        //        country = country.Where(cn => cn.CountryName!.Contains(text));
        //    }

        //    return View("Index", await country.ToListAsync());
        //}
    }
}


