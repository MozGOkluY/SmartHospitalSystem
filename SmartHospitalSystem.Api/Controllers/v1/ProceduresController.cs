using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHospitalSystem.Api.Requests;
using SmartHospitalSystem.Api.Responses;
using SmartHospitalSystem.Core.Constants;
using SmartHospitalSystem.Core.Interfaces.Managers;
using SmartHospitalSystem.Core.Interfaces.Repositories;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Api.Controllers
{
    /// <summary>
    /// The controller allows managing the patients
    /// </summary>
    [Authorize(Roles = AuthRoles.ADMIN_REGISTRY)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProceduresController : Controller
    {
        private readonly IProcedureRepository _procedureRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Procedures controller constructor
        /// </summary>
        public ProceduresController(IProcedureRepository procedureRepository, IMapper mapper)
        {
            _procedureRepository = procedureRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get procedure by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(PatientResponse), 200)]
        [Route("{id}")]
        public async Task<IActionResult> GetProcedureById([FromRoute] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id is null or invalid");
            }

            var procedure = await _procedureRepository.FindAsync(id);

            if (procedure == null)
            {
                return BadRequest("Procedure not exist");
            }

            var procedureResponse = _mapper.Map<ProcedureResponse>(procedure);

            return Ok(procedureResponse);
        }

        /// <summary>
        /// Get all procedures
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(PatientResponse), 200)]
        public async Task<IActionResult> GetProceduresAsync()
        {
            var procedures = await _procedureRepository.SelectAllAsync();

            var responses = procedures.Select(x => _mapper.Map<ProcedureResponse>(x)).ToList();
            var response = new ProceduresResponse
            {
                Procedures = responses
            };

            return Ok(response);
        }

        /// <summary>
        /// Create new procedure
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(PatientResponse), 200)]
        public async Task<IActionResult> PostProceduresAsync([FromBody] CreateProcedureRequest createProcedureRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid");
            }

            var model = _mapper.Map<ProcedureModel>(createProcedureRequest);
            await _procedureRepository.InsertAsync(model);
            var response = _mapper.Map<CreateProcedureResponse>(model);

            return Ok(response);
        }

        /// <summary>
        /// Delete procedure by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(PatientResponse), 200)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProcedureById([FromRoute] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id is null or invalid");
            }

            var result = await _procedureRepository.DeleteByIdAsync(id);

            if (result)
            {
                return BadRequest("Procedure not exist");
            }

            return Ok();
        }
    }
}
