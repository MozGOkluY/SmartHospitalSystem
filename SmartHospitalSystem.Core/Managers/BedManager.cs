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
    public class BedManager : IBedManager
    {
        private readonly IBedRepository _bedRepository;

        /// <summary>
        /// Constructor of DepartmentManager
        /// </summary>
        /// <param name="bedRepository"></param>
        public BedManager(IBedRepository bedRepository)
        {
            _bedRepository = bedRepository;
        }

        /// <inheritdoc />
        public Task<bool> DeleteBedAsync(string id)
        {
            return _bedRepository.DeleteByIdAsync(id);
        }

        /// <inheritdoc />
        public Task<List<BedModel>> GetAllBeds()
        {
            return _bedRepository.SelectAllAsync();
        }

        /// <inheritdoc />
        public Task<BedModel> GetById(string id)
        {
            return _bedRepository.FindAsync(id);
        }

        /// <inheritdoc />
        public Task InsertBedAsync(BedModel bedModel)
        {
            return _bedRepository.InsertAsync(bedModel);
        }

        /// <inheritdoc />
        public Task UpdateBedAsync(BedModel bedModel)
        {
            return _bedRepository.ReplaceByIdAsync(bedModel.BedId, bedModel);
        }
    }
}
