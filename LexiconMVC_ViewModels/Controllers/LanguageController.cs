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
    public class LanguageController : Controller
    {
        private ApplicationDbContext _context;

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Languages.ToList());
        }

        // GET: LanguageController/Create
        [HttpGet]
        public ActionResult Create()
        {
            CreateLanguageViewModel model = new CreateLanguageViewModel();

            return View(model);
        }

        // POST: LanguageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLanguageViewModel createLanguage)
        {
            if (ModelState.IsValid)
            {
                Language language = new Language()
                {
                    LanguageName = createLanguage.LanguageName
                };
                _context.Languages.Add(language);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index), "Language");
        }

       
        public ActionResult Delete(int id)
        {
            var languageToDelete = _context.Languages.FirstOrDefault(x => x.LanguageId == id);
            if (languageToDelete != null)
            {
                _context.Languages.Remove(languageToDelete);
                _context.SaveChanges();
            }
            
            return RedirectToAction(nameof(Index), "Language");
        }
    }
}
