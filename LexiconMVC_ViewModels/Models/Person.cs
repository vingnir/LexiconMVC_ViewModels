using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconMVC_ViewModels.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("City")]
        public int CurrentCityId { get; set; }
        public City City { get; set; }

        public List<PersonLanguage> Languages { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
