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
        private static bool listPopulated;

        public PersonData Create(PersonData personData)
        {
            PersonData newPersonData = new PersonData();
            newPersonData.Id = ++idCounter;
            newPersonData.Name = personData.Name;
            newPersonData.City = personData.City;
            newPersonData.PhoneNumber = personData.PhoneNumber;
            newPersonData.Created = System.DateTime.Now;           
            listOfPersonData.Add(newPersonData);
            return newPersonData;
        }

        public List<PersonData> Read()
        {
            if (!listPopulated) { PopulateList(); }

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

            return listOfPersonData.Remove(original);
        }

        public static void PopulateList()
        {
            string[] names = { "Kalle Kanin", "Kalle Anka", "Donald Duck", "Mimmy Mouse" };
            string[] citys = { "Göteborg", "Stockholm", "Oslo", "Berlin" };
            string[] phone = { "070-123456", "070-987456", "070-111111", "070-963258" };

            for (int i = 1; i < names.Length; i++)
            {
                PersonData newPersonToList = new PersonData();
                newPersonToList.Id = ++idCounter;
                newPersonToList.Name = names[i];
                newPersonToList.City = citys[i];
                newPersonToList.PhoneNumber = phone[i];
                newPersonToList.Created = System.DateTime.Now;
                listOfPersonData.Add(newPersonToList);
            }
            listPopulated = true;
        }

    }
}
