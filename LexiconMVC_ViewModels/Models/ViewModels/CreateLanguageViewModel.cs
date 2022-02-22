using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Name of language")]

        public string LanguageName { get; set; }
        public CreateLanguageViewModel() { }

        public CreateLanguageViewModel(string languageName)
        {
            LanguageName = languageName; 
        }

        
    }
}
