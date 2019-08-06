using System.Collections.Generic;
using System.Threading.Tasks;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Core.Interfaces.Managers
{
    /// <summary>
    /// Managing of beds and business logic for them
    /// </summary>
    public interface IBedManager
    {
        /// <summary>
        /// Returns model of user by id
        /// </summary>
        /// <param name="id">Id of existing user</param>
        /// <returns></returns>
        Task<BedModel> GetById(string id);

        /// <summary>
        /// Returns all existing bed
        /// </summary>
        /// <returns></returns>
        Task<List<BedModel>> GetAllBeds();

        /// <summary>
        /// Inserts new bedModel in Db
        /// </summary>
        /// <param name="bedModel">Model of bed that will be inserted</param>
        /// <returns></returns>
        Task InsertBedAsync(BedModel bedModel);

        /// <summary>
        /// Updates existing bed in Db
        /// </summary>
        /// <param name="bedModel">Model of bed that will be updated</param>
        /// <returns></returns>
        Task UpdateBedAsync(BedModel bedModel);

        /// <summary>
        /// Deletes existing bed in Db
        /// </summary>
        /// <param name="id">Id of user that will be deleted</param>
        /// <returns></returns>
        Task<bool> DeleteProfileAsync(string id);
    }
}
