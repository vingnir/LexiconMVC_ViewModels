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
        [Display(Name = "City")]
        public int CurrentCityId { get; set; }
       
        public string PhoneNumber { get; set; }

        public List<City> Cities { get; set; }

        public List<PersonLanguage> Languages { get; set; }
    }
}
