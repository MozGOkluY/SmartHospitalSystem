using System.Collections.Generic;
using System.Threading.Tasks;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Core.Interfaces.Managers
{
    /// <summary>
    /// Managing of patients and business logic for them
    /// </summary>
    public interface IPatientManager
    {
        /// <summary>
        /// Returns model of user by id
        /// </summary>
        /// <param name="profile">Profile of existing user</param>
        /// <returns></returns>
        Task<PatientModel> GetPatient(UserProfile profile);

        /// <summary>
        /// Creates new visit for patient
        /// </summary>
        /// <param name="id">Profile of existing user</param>
        /// <returns></returns>
        Task CreateVisitForPatient(VisitModel visitModel);
    }
}
