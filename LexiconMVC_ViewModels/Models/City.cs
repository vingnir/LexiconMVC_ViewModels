using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models
{
    public class City
    {
        [Key]
        [Required]
        [Display(Name = "Name of City")]
        public string CityName { get; set; }
        public List<Person> People { get; set; }
    }
}
