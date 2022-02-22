﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LexiconMVC_ViewModels.Models;
using Microsoft.EntityFrameworkCore;
using LexiconMVC_ViewModels.Models.ViewModels;


namespace LexiconMVC_ViewModels.Models.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //Recommend on the first line inside method.

            //#region PersonLanguage Join Class Config

            modelBuilder.Entity<PersonLanguage>().HasKey(pl => new { pl.PersonId, pl.LanguageId });

            modelBuilder.Entity<PersonLanguage>()
            .HasOne<Person>(pl => pl.Person)
            .WithMany(p => p.Languages)
            .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PersonLanguage>()
            .HasOne(pl => pl.Language)
            .WithMany(p => p.People)
            .HasForeignKey(pl => pl.LanguageId);

            modelBuilder.Entity<City>().HasData(new City { CityName = "Bangkok" });
            modelBuilder.Entity<City>().HasData(new City { CityName = "Berlin" });
            modelBuilder.Entity<City>().HasData(new City { CityName = "Bangalore" });

            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Bangladesh" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Baharain" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Spain" });


            modelBuilder.Entity<Person>().HasData(new Person { Id = 666, Name = "Doggy Dog", PhoneNumber ="12345-7899" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 999, Name = "Kalle Kanin", PhoneNumber = "12345-7585" });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 123, Name = "Hasse Hare", PhoneNumber = "12345-8522" });

            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 123, LanguageName = "Chinese" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 124, LanguageName = "Portuguese" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 125, LanguageName = "Spanish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 126, LanguageName = "Finnish" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 127, LanguageName = "Esperanto" });

          //  #endregion
        }

        public DbSet<Person> People { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<PersonLanguage> PersonLanguage { get; set; }
        public DbSet<Language> Language { get; set; }
    }
}
