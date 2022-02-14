using LexiconMVC_ViewModels.Models.Entitys;
using LexiconMVC_ViewModels.Models.Services;
using LexiconMVC_ViewModels.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IPersonDataService _personDataService;
        public AjaxController()
        {
            _personDataService = new PersonDataService();
        }
        public IActionResult Index()
        {
            return View();
        }

        //PartialView Actions
        [HttpGet]
        public IActionResult People()
        {
            List<PersonData> personData = _personDataService.GetList();
            PeopleViewModel people;

            List<PeopleViewModel> listOfPeople = new List<PeopleViewModel>();

            if (personData != null)
            {
                foreach (PersonData item in personData)
                {
                    people = new PeopleViewModel();

                    people.Id = item.Id;
                    people.Name = item.Name;
                    people.City = item.City;
                    people.PhoneNumber = item.PhoneNumber;
                    listOfPeople.Add(people);
                }
                return PartialView("_People", listOfPeople);
            }

            return PartialView("_People", listOfPeople);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            PersonData personData = _personDataService.GetById(id);
            if (personData == null)
            {
                return RedirectToAction(nameof(Index), "People");
            }
            return PartialView("_People", personData);
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool confirm)
        {
            confirm = _personDataService.Delete(id);
            if (confirm)
            {
                return PartialView("_People");
                //return View("Index");
            }


           return PartialView("_People");
        }
    }
}
