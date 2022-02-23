using LexiconMVC_ViewModels.Models;
using LexiconMVC_ViewModels.Models.Data;
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
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: CountryController/Details/5
        public IActionResult Details(string CountryName)
        {

            return View("Details", _context.Countries.Find(CountryName));

        }

        
        public ActionResult Delete(string CountryName)
        {
            var countryToDelete = _context.Countries.FirstOrDefault(x => x.CountryName == CountryName);
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


