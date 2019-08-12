using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHospitalSystem.Api.Responses;
using SmartHospitalSystem.Core.Constants;
using SmartHospitalSystem.Core.Interfaces.Managers;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Api.Controllers
{
    /// <summary>
    /// The controller allows managing the patients
    /// </summary>
    [Authorize(Roles = AuthRoles.ADMIN_REGISTRY)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatientsController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IBedManager _bedManager;
        private readonly IPatientManager _patientManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// Users controller constructor
        /// </summary>
        public PatientsController(IUserManager userManager, IBedManager bedManager, IPatientManager patientManager, IMapper mapper)
        {
            _userManager = userManager;
            _bedManager = bedManager;
            _patientManager = patientManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Get patient by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(PatientResponse), 200)]
        [Route("{id}")]
        public async Task<IActionResult> GetPatientByIdAsync([FromRoute] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id is null or invalid");
            }

            var user = await _userManager.GetById(id);

            if (user == null)
            {
                return BadRequest("Patient not found");
            }

            var patient = await _patientManager.GetPatientDto(user);

            var userResponse = _mapper.Map<UserResponse>(patient.UserData);
            var visitsResponse = patient.Visits.Select(x => _mapper.Map<VisitReponse>(x)).ToList();
            var response = _mapper.Map<PatientResponse>(patient);

            return Ok(response);
        }

        /// <summary>
        /// Creates visit for patient
        /// </summary>
        /// <param name="id">Patient id</param>
        /// <param name="visitRequest">Visit request</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(PatientResponse), 200)]
        [Route("{id}")]
        public async Task<IActionResult> CreateVisitAsync([FromRoute] string id, [FromBody] VisitRequest visitRequest)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id is null or invalid");
            }
            
            if (!string.Equals(id, visitRequest.UserProfileId, System.StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Inconsistency in ids");
            }

            var user = await _userManager.GetById(id);

            if (user == null)
            {
                return BadRequest("Patient not found");
            }

            var visit = _mapper.Map<VisitModel>(visitRequest);
            await _patientManager.CreateVisitForPatient(visit);
            var visitResponse = _mapper.Map<VisitReponse>(visit);

            return Ok(visitResponse);
        }

        /// <summary>
        /// Creates visit for patient
        /// </summary>
        /// <param name="id">Patient id</param>
        /// <param name="bedId">Bed id</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 200)]
        [Route("{id}/bed/{bedId}")]
        public async Task<IActionResult> AssignPatientToBed([FromRoute] string id, [FromRoute] string bedId)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(bedId))
            {
                return BadRequest("Some id is null or empty");
            }

            var bed = await _bedManager.GetById(bedId);

            if (bed == null)
            {
                return BadRequest("Bed not found");
            }

            var patient = await _userManager.GetById(id);

            if (patient == null)
            {
                return BadRequest("Patient not found");
            }

            bed.PatientId = patient.Id;

            await _bedManager.UpdateBedAsync(bed);

            return Ok("Assigned");
        }
    }
}
