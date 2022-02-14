using LexiconMVC_ViewModels.Models.Entitys;
using LexiconMVC_ViewModels.Models.Repo;
using LexiconMVC_ViewModels.Models.ViewModels;
using LexiconMVC_ViewModels.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models.Services
{
    public class PersonDataService : IPersonDataService
    {
        private readonly IPersonDataRepo _personDataRepo;

        public PersonDataService()
        {
            _personDataRepo = new InMemoryPersonDataRepo();
        }

        public PersonData Add(CreatePersonViewModel personDataVM)
        {
            if (string.IsNullOrWhiteSpace(personDataVM.Name) || string.IsNullOrWhiteSpace(personDataVM.City))
            {
                return null;
            }
            PersonData newPersonData = new PersonData()
            {
                Name = personDataVM.Name,
                City = personDataVM.City,
                PhoneNumber = personDataVM.PhoneNumber
            };

            PersonData personData = _personDataRepo.Create(newPersonData);

            return personData;
        }

        public PersonData GetById(int id)
        {
            return _personDataRepo.Read(id);
        }

        public List<PersonData> GetList()
        {
            return _personDataRepo.Read();
        }

        public List<PersonData> Search(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new List<PersonData>();
            }

            var list = _personDataRepo.Read();
            List<PersonData> matches = new List<PersonData>();

            foreach (var item in list)
            {
                if (item.Name.Contains(text))
                {
                    matches.Add(item);
                }
            }

            return matches;
        }

        public PersonData Edit(int id, CreatePersonViewModel personData)
        {
            PersonData editPersonData = new PersonData()
            {
                Id = id,
                Name = personData.Name,
                City = personData.City,
                PhoneNumber = personData.PhoneNumber
            };
            return _personDataRepo.Update(editPersonData);
        }

        public bool Delete(int id)
        {
            return _personDataRepo.Delete(id);
        }
    }
}
