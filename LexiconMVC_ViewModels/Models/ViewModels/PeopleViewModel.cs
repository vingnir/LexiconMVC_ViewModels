using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models.ViewModels
{
    public class PeopleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public PeopleViewModel() { }

        public PeopleViewModel(string name, string city, string phoneNumber)
        {
            Name = name;
            City = city;
            PhoneNumber = phoneNumber;
        }
    }
}
