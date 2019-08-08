using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHospitalSystem.Api.Requests;
using SmartHospitalSystem.Api.Responses;
using SmartHospitalSystem.Core.Constants;
using SmartHospitalSystem.Core.Interfaces.Managers;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Api.Controllers
{
    /// <summary>
    /// The controller allows managing the departments
    /// </summary>
    [Authorize(Roles = AuthRoles.ADMIN)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentManager _departmentManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// TokensController constructor
        /// </summary>
        public DepartmentsController(IDepartmentManager departmentManager, IMapper mapper)
        {
            _departmentManager = departmentManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates new department in hospital
        /// </summary>
        /// <param name="createDepartmentRequest">Request model</param>
        /// <returns>Created department</returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(CreateDepartmentResponse), 200)]
        public async Task<IActionResult> CreateDepartmentAsync([FromBody] CreateDepartmentRequest createDepartmentRequest)
        {
            if (string.IsNullOrWhiteSpace(createDepartmentRequest.DepartmentName))
            {
                return BadRequest("Invalid department name");
            }

            var model = _mapper.Map<DepartmentModel>(createDepartmentRequest);
            await _departmentManager.InsertDepartmentAsync(model);
            var response = _mapper.Map<CreateDepartmentResponse>(model);

            return Ok(response);
        }

        /// <summary>
        /// Get department by id
        /// </summary>
        /// <param name="id">Department id</param>
        /// <returns>Created department</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(DepartmentResponse), 200)]
        [Route("{id}")]
        public async Task<IActionResult> GetDepartmentByIdAsync([FromRoute] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id is null or invalid");
            }

            var department = await _departmentManager.GetById(id);

            if (department == null)
            {
                return BadRequest("Department not found");
            }

            var response = _mapper.Map<DepartmentResponse>(department);
            return Ok(response);
        }

        /// <summary>
        /// Get department by id
        /// </summary>
        /// <returns>All departments</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(DepartmentResponse), 200)]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            var result = await _departmentManager.GetAllDepartments();
            var departs = result.Select(x => _mapper.Map<DepartmentResponse>(x)).ToList();
            var response = new DepartmentsResponse
            {
                Departments = departs
            };

            return Ok(response);
        }

        /// <summary>
        /// Updates new department in hospital
        /// </summary>
        /// <param name="id">Department id</param>
        /// <param name="updateUserRequest">Request model</param>
        /// <returns>Updated department</returns>
        [HttpPut]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(UpdateDepartmentResponse), 200)]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDepartmentAsync([FromQuery] string id, [FromBody] UpdateDepartmentRequest updateUserRequest)
        {
            if (string.IsNullOrWhiteSpace(updateUserRequest.DepartmentName))
            {
                return BadRequest("Invalid department name");
            }

            if (!string.Equals(id, updateUserRequest.DepartmentId, System.StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Inconsistency in departments id's");
            }

            var department = await _departmentManager.GetById(id);

            if (department == null)
            {
                return BadRequest("Department not found");
            }

            var model = _mapper.Map<DepartmentModel>(updateUserRequest);
            await _departmentManager.UpdateDepartmentAsync(model);
            var response = _mapper.Map<UpdateDepartmentResponse>(model);

            return Ok(response);
        }

        /// <summary>
        /// Deletes department in hospital
        /// </summary>
        /// <param name="id">Department id</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 200)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDepartmentAsync([FromQuery] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id is null or empty");
            }

            var result = await _departmentManager.DeleteDepartmentAsync(id);

            if (result)
            {
                return BadRequest("Department not found");
            }

            return Ok();
        }
    }
}
