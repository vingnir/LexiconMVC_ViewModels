using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models
{
    public class Country
    {
        [Key]
        [Required]
        [Display(Name = "Name of Country")]
        public string CountryName { get; set; }
     
        public List<City> Cities { get; set; }
    }
}
