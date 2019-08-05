using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SmartHospitalSystem.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Get values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
