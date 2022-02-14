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
    }
}
