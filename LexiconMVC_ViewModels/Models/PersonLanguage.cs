using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models
{
    public class PersonLanguage //Join tabel class
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
