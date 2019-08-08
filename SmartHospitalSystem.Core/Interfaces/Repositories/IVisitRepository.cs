using System.Collections.Generic;
using System.Threading.Tasks;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Core.Interfaces.Repositories
{
    /// <summary>
    /// Reposirotry for Treatment cards
    /// </summary>
    public interface IVisitRepository : IRepositoryBase<VisitModel>
    {
        /// <summary>
        /// Get by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<VisitModel>> GetByUserId(string userId);
    }
}
