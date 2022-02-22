using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models.ViewModels
{
    public class CreateCityViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name of City")]

        public string CityName { get; set; }
    }
}
