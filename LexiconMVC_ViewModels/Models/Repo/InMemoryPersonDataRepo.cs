using LexiconMVC_ViewModels.Models.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models.Repo
{
    public class InMemoryPersonDataRepo : IPersonDataRepo
    {
        private static int idCounter = 0;
        private static List<PersonData> listOfPersonData = new List<PersonData>();

        public PersonData Create(PersonData personData)
        {
            PersonData newPersonData = new PersonData();
            newPersonData.Id = ++idCounter;
            newPersonData.Name = personData.Name;
            newPersonData.City = personData.City;
            newPersonData.Created = System.DateTime.Now;

            listOfPersonData.Add(newPersonData);
            return newPersonData;
        }

        public List<PersonData> Read()
        {
            return listOfPersonData;
        }

        public PersonData Read(int id)
        {
            return listOfPersonData.SingleOrDefault(c => c.Id == id);
        }

        public PersonData Update(PersonData personData)
        {
            PersonData original = Read(personData.Id);

            if (original == null)
            {
                return null;
            }

            original.Name = personData.Name;
            original.City = personData.City;
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

            return listOfPersonData.Remove(original);
        }
    }
}
