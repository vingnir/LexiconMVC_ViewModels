using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Name of Country")]

        public string CountryName { get; set; }
    }
}
