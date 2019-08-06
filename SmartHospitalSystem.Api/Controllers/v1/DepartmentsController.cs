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
    /// The controller allows managing the units
    /// </summary>
    [Authorize]
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
        /// Creates new unit in hospital
        /// </summary>
        /// <param name="createDepartmentRequest">Request model</param>
        /// <returns>Created department</returns>
        [Authorize(Roles = AuthRoles.ADMIN)]
        [HttpPost]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(CreateDepartmentResponse), 200)]
        public async Task<IActionResult> CreateDepartment([FromBody]CreateDepartmentRequest createDepartmentRequest)
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
    }
}
