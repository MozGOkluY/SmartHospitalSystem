using System.Collections.Generic;
using System.Threading.Tasks;
using SmartHospitalSystem.Core.Interfaces.Managers;
using SmartHospitalSystem.Core.Interfaces.Repositories;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Core.Managers
{
    /// <summary>
    /// Managing of users and business logic for them
    /// </summary>
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepository _departmentRepository;

        /// <summary>
        /// Constructor of DepartmentManager
        /// </summary>
        /// <param name="departmentRepository"></param>
        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        /// <inheritdoc />
        public Task<bool> DeleteDepartmentAsync(string id)
        {
            return _departmentRepository.DeleteByIdAsync(id);
        }

        /// <inheritdoc />
        public Task<List<DepartmentModel>> GetAllDepartments()
        {
            return _departmentRepository.SelectAllAsync();
        }

        /// <inheritdoc />
        public Task<DepartmentModel> GetById(string id)
        {
            return _departmentRepository.FindAsync(id);
        }

        /// <inheritdoc />
        public Task InsertDepartmentAsync(DepartmentModel departmentModel)
        {
            return _departmentRepository.InsertAsync(departmentModel);
        }

        /// <inheritdoc />
        public Task<bool> UpdateDepartmentAsync(DepartmentModel departmentModel)
        {
            return _departmentRepository.ReplaceByIdAsync(departmentModel.DepartmentId, departmentModel);
        }
    }
}
