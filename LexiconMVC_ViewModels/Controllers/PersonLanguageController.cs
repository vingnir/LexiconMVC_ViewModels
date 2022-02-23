using LexiconMVC_ViewModels.Models;
using LexiconMVC_ViewModels.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Controllers
{
    public class PersonLanguageController : Controller
    {
        private ApplicationDbContext _context;

        public PersonLanguageController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name");
            ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageName");

            return View();
        }

        [HttpPost]
        public IActionResult CreatePersonLanguage(PersonLanguage personLanguage)
        {
            _context.PersonLanguages.Add(personLanguage);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
