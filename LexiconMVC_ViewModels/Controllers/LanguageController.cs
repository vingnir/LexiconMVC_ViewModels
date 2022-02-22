using LexiconMVC_ViewModels.Models;
using LexiconMVC_ViewModels.Models.Data;
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
            return View(_context.Language.ToList());
        }



        // GET: LanguageController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: LanguageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Language language)
        {
            if (ModelState.IsValid)
            {
                _context.Language.Add(language);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

      

        public ActionResult Delete(int LanguageId)
        {
            var LanguageToDelete = _context.Language.FirstOrDefault(x => x.LanguageId == LanguageId);
            _context.Language.Remove(LanguageToDelete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Language");
        }
    }
}
