using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LexiconMVC_ViewModels.Models;
using Microsoft.EntityFrameworkCore;
using LexiconMVC_ViewModels.Models.ViewModels;


namespace LexiconMVC_ViewModels.Models.Repo
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person { Id=666, Name="Doggy Dog", City="Dog Town", PhoneNumber ="12345-7899" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 999, Name = "Kalle Kanin", City = "Rabbit Town", PhoneNumber = "12345-7585" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 123, Name = "Hasse Hare", City = "Rabbit Town", PhoneNumber = "12345-8522" });
        }

        public DbSet<LexiconMVC_ViewModels.Models.ViewModels.PeopleViewModel> PeopleViewModel { get; set; }
    }
}
