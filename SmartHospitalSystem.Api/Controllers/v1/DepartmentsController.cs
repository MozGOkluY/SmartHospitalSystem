using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// TokensController constructor
        /// </summary>
        public DepartmentsController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        /// <summary>
        /// Creates new unit in hospital
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<IActionResult> CreateDepartment([FromBody]CreateDepartmentRequest createDepartmentRequest)
        {   
           return NotFound("Profile with give login not found");
        }
    }
}
