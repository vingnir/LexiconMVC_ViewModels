using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LexiconMVC_ViewModels.Models.Entitys;
using Microsoft.EntityFrameworkCore;


namespace LexiconMVC_ViewModels.Models.Repo
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() 
        {

        }

        public DbSet<PersonData> People { get; set; }

    }
}
