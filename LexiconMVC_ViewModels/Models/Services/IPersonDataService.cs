using LexiconMVC_ViewModels.Models.Entitys;
using LexiconMVC_ViewModels.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models.Services
{
    public interface IPersonDataService
    {
        /// <summary>
        /// Adds new PersonData.
        /// </summary>
        /// <param name="personDataVM">Create view model of PersonData to be added</param>
        /// <returns>Returns added PersonData or null if it fails</returns>
        PersonData Add(CreatePersonViewModel personDataVM);

        /// <summary>
        /// Gets the PersonData with the provided Id.
        /// </summary>
        /// <param name="id">Id of a PersonData</param>
        /// <returns>Returns PersonData with same Id or null if not able to get it</returns>
        PersonData GetById(int id);

        /// <summary>
        /// Returns list of PersonData´s.
        /// </summary>
        /// <returns>list of PersonData´s</returns>
        List<PersonData> GetList();

        /// <summary>
        /// Searches if any PersonData Name contains the following text
        /// </summary>
        /// <param name="text">Text to look for</param>
        /// <returns>Returns list of matching PersonData´s</returns>
        List<PersonData> Search(string text);

        /// <summary>
        /// Edit PersonData using the Id and ViewModel provided.
        /// </summary>
        /// <param name="id">Id of PersonData to edit</param>
        /// <param name="personData">Create ViewModel of PersonData to contain edited information and use the same validation as when you create</param>
        /// <returns>Returns edited PersonData or null if edit failed</returns>
        PersonData Edit(int id, CreatePersonViewModel personData);

        /// <summary>
        /// Delete PersonData with provided Id
        /// </summary>
        /// <param name="id">Id of PersonData to delete</param>
        /// <returns>Returns True if PersonData was deleted or False if it was not deleted alse False if it does not excist.</returns>
        bool Delete(int id);
    }
}
