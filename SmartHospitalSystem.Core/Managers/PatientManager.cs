using System.Threading.Tasks;
using SmartHospitalSystem.Core.Interfaces.Managers;
using SmartHospitalSystem.Core.Interfaces.Repositories;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Core.Managers
{
    /// <summary>
    /// Managing of users and business logic for them
    /// </summary>
    public class PatientManager : IPatientManager
    {
        private readonly IUserManager _userManager;
        private readonly IVisitRepository _visitRepository;

        /// <summary>
        /// Constructor of PatientManager
        /// </summary>
        /// <param name="visitRepository"></param>
        public PatientManager(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        /// <inheritdoc />
        public async Task<PatientModel> GetPatient(UserProfile profile)
        {
            var visits = await _visitRepository.GetByUserId(profile.Id);

            var toRet = new PatientModel
            {
                UserData = profile,
                Visits = visits
            };
            return toRet;
        }

        /// <inheritdoc />
        public Task CreateVisitForPatient(VisitModel visitModel)
        {
            return _visitRepository.InsertAsync(visitModel);
        }
    }
}
