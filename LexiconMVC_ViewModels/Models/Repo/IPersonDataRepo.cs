using LexiconMVC_ViewModels.Models.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVC_ViewModels.Models.Repo
{
    interface IPersonDataRepo
    {
        //C.R.U.D for PersonData

        /// <summary>
        /// Creates a new PersonData with a unique Id and saves it to storage.
        /// </summary>
        /// <param name="PersonData">PersonData to be created and stored</param>
        /// <returns>Returns created PersonData</returns>
        PersonData Create(PersonData personData);

        /// <summary>
        /// Returns list of stored PersonData
        /// </summary>
        /// <returns>Returns list of stored PersonData</returns>
        List<PersonData> Read();

        /// <summary>
        /// Finds the PersonData in the storage with the provided Id
        /// </summary>
        /// <param name="id">Id of PersonData to find</param>
        /// <returns>Returns PersonData if found, returns null if not found</returns>
        PersonData Read(int id);

        /// <summary>
        /// Updates PersonData in storage and returns it.
        /// </summary>
        /// <param name="personData">PersonData to be updated in storage</param>
        /// <returns>Returns updated PersonData, Returns null if PersonData can not be found</returns>
        PersonData Update(PersonData personData);

        /// <summary>
        /// Deletes PersonData with provided Id from storage if found.
        /// </summary>
        /// <param name="id">Id of PersonData to delete from storage</param>
        /// <returns>Returns True if deleted, False if not deleted</returns>
        bool Delete(int id);
    }
}
