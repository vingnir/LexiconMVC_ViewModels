using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        [Display(Name = "Name of language")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LanguageName { get; set; }
        
        public List<PersonLanguage> People { get; set; }

    }
}
