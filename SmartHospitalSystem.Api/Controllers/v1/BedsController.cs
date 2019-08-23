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
    /// The controller allows managing the beds
    /// </summary>
    [Authorize(Roles = AuthRoles.ADMIN)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BedsController : Controller
    {
        private readonly IBedManager _bedManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// Beds controller constructor
        /// </summary>
        public BedsController(IBedManager bedManager, IMapper mapper)
        {
            _bedManager = bedManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates new bed in hospital
        /// </summary>
        /// <param name="createBedRequest">Request model</param>
        /// <returns>Created bed</returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(CreateBedResponse), 200)]
        public async Task<IActionResult> CreateBedAsync([FromBody] CreateBedRequest createBedRequest)
        {
            if (string.IsNullOrWhiteSpace(createBedRequest.BedName))
            {
                return BadRequest("Bed name is null or invalid");
            }

            var model = _mapper.Map<BedModel>(createBedRequest);
            await _bedManager.InsertBedAsync(model);
            var response = _mapper.Map<CreateBedResponse>(model);

            return Ok(response);
        }

        /// <summary>
        /// Get bed by id
        /// </summary>
        /// <param name="id">Bed id</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(BedResponse), 200)]
        [Route("{id}")]
        public async Task<IActionResult> GetBedByIdAsync([FromRoute] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id is null or empty");
            }

            var bed = await _bedManager.GetById(id);
            if (bed == null)
            {
                return BadRequest("Bed not found");
            }

            var response = _mapper.Map<BedResponse>(bed);
            return Ok(response);
        }

        /// <summary>
        /// Get all beds
        /// </summary>
        /// <returns>All Beds</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(BedsResponse), 200)]
        public async Task<IActionResult> GetAllBedsAsync()
        {
            var result = await _bedManager.GetAllBeds();
            var departs = result.Select(x => _mapper.Map<BedResponse>(x)).ToList();
            var response = new BedsResponse
            {
                Beds = departs
            };

            return Ok(response);
        }

        /// <summary>
        /// Updates new Bed in hospital
        /// </summary>
        /// <param name="id">Bed id</param>
        /// <param name="updateBedRequest">Request model</param>
        /// <returns>Updated Bed</returns>
        [HttpPut]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(UpdateBedResponse), 200)]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBedAsync([FromRoute] string id, [FromBody] UpdateBedRequest updateBedRequest)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id is null or empty");
            }

            if (!string.Equals(id, updateBedRequest.BedId, System.StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Inconsistency in Beds id's");
            }

            var model = _mapper.Map<BedModel>(updateBedRequest);
            var result = await _bedManager.UpdateBedAsync(model);

            if (!result)
            {
                return BadRequest("Bed not found");
            }

            var response = _mapper.Map<UpdateBedResponse>(model);

            return Ok(response);
        }

        /// <summary>
        /// Deletes Bed in hospital
        /// </summary>
        /// <param name="id">Bed id</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 200)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBedByIdAsync([FromRoute] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id is null or empty");
            }

            var result = await _bedManager.DeleteBedAsync(id);
            if (result)
            {
                return BadRequest("Bed not found");
            }

            return Ok();
        }
    }
}
