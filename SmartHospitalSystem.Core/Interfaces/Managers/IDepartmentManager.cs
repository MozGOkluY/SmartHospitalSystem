using System.Collections.Generic;
using System.Threading.Tasks;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Core.Interfaces.Managers
{
    /// <summary>
    /// Managing of departments and business logic for them
    /// </summary>
    public interface IDepartmentManager
    {
        /// <summary>
        /// Returns model of user by id
        /// </summary>
        /// <param name="id">Id of existing user</param>
        /// <returns></returns>
        Task<DepartmentModel> GetById(string id);

        /// <summary>
        /// Returns all existing department
        /// </summary>
        /// <returns></returns>
        Task<List<DepartmentModel>> GetAllDepartments();

        /// <summary>
        /// Inserts new department in Db
        /// </summary>
        /// <param name="departmentModel">Model of department that will be inserted</param>
        /// <returns></returns>
        Task InsertDepartmentAsync(DepartmentModel departmentModel);

        /// <summary>
        /// Updates existing department in Db
        /// </summary>
        /// <param name="departmentModel">Model of department that will be updated</param>
        /// <returns></returns>
        Task<bool> UpdateDepartmentAsync(DepartmentModel departmentModel);

        /// <summary>
        /// Deletes existing department in Db
        /// </summary>
        /// <param name="id">Id of user that will be deleted</param>
        /// <returns></returns>
        Task<bool> DeleteDepartmentAsync(string id);
    }
}
