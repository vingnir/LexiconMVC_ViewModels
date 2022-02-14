using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconMVC_ViewModels.Models.Entitys
{
    public class PersonData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
