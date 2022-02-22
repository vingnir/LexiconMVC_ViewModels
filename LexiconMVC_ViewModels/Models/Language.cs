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
        [Required]
        public string LanguageName { get; set; }
        //[ForeignKey("Id")]
        public int PersonId { get; set; }
        public List<PersonLanguage> People { get; set; }

    }
}
