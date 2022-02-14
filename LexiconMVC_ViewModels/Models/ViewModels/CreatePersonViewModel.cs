using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconMVC_ViewModels.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name")]

        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "City")]

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public CreatePersonViewModel() { }

        public CreatePersonViewModel(string name, string city, string phoneNumber)
        {
            Name = name;
            City = city;
            PhoneNumber = phoneNumber;
        }
    }
}
