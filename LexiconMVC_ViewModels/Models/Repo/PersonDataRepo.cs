using LexiconMVC_ViewModels.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models.Repo
{
    public class PersonDataRepo : IPersonDataRepo
    {
        private ApplicationDbContext _context;

        
        public PersonDataRepo(ApplicationDbContext context)
        {
           _context = context;
        }
        public PersonData Create(PersonData personData)
        {
           _context.Add(personData);
           _context.SaveChanges();
            return personData;
        }

        public List<PersonData> Read()
        {
           

            return _context.People.ToList();
        }

        public PersonData Read(int id)
        {
            return _context.People.Find(id);
            //return listOfPersonData.SingleOrDefault(c => c.Id == id);
        }

        public PersonData Update(PersonData personData)
        {
            PersonData original = Read(personData.Id);

            if (original == null)
            {
                return null;
            }

            _context.Entry(personData).State = EntityState.Modified;

            original.Name = personData.Name;
            original.City = personData.City;
            original.PhoneNumber = personData.PhoneNumber;
            original.Edited = System.DateTime.Now;

            return original;
        }

        public bool Delete(int id)
        {
            PersonData original = Read(id);

            if (original == null)
            {
                return false;
            }
            _context.People.Remove(original);

            return true;
        }

        

    }
}
