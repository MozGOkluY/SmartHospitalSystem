﻿using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHospitalSystem.Api.Requests;
using SmartHospitalSystem.Api.Responses;
using SmartHospitalSystem.Core.Constants;
using SmartHospitalSystem.Core.Enums;
using SmartHospitalSystem.Core.Interfaces.Managers;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Api.Controllers
{
    /// <summary>
    /// The controller allows managing the users
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// Users controller constructor
        /// </summary>
        public UsersController(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates new user in hospital
        /// </summary>
        /// <param name="createUserRequest">Request model</param>
        /// <returns>Created user</returns>
        [Authorize(Roles = AuthRoles.ADMIN_REGISTRY)]
        [HttpPost]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(CreateUserRequest), 200)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest createUserRequest)
        {
            if (createUserRequest.Roles.Contains(UserRoleEnum.Admin)
                && !HttpContext.User.IsInRole(UserRoleEnum.Admin.ToString()))
            {
                return BadRequest("Not enough rights");
            }

            var model = _mapper.Map<UserProfile>(createUserRequest);
            await _userManager.InsertProfileAsync(model);
            var response = _mapper.Map<CreateUserResponse>(model);

            return Ok(response);
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [Authorize(Roles = AuthRoles.ADMIN)]
        [HttpGet]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [Route("{id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id is null or invalid");
            }

            var result = await _userManager.GetById(id);
            var response = _mapper.Map<UserResponse>(result);

            return Ok(response);
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <returns>All users</returns>
        [Authorize(Roles = AuthRoles.ADMIN)]
        [HttpGet]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(UsersResponse), 200)]
        public async Task<IActionResult> GetAllusersAsync()
        {
            var result = await _userManager.GetAllUsers();
            var users = result.Select(x => _mapper.Map<UserResponse>(x)).ToList();
            var response = new UsersResponse
            {
                Users = users
            };

            return Ok(response);
        }

        /// <summary>
        /// Updates new user in hospital
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="updateUserRequest">Request model</param>
        /// <returns>Updated user</returns>
        [Authorize(Roles = AuthRoles.ADMIN)]
        [HttpPut]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(UpdateUserResponse), 200)]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUserAsync([FromQuery] string id, [FromBody] UpdateUserRequest updateUserRequest)
        {
            if (!string.Equals(id, updateUserRequest.Id, System.StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Inconsistency in users id's");
            }

            var user = await _userManager.GetById(id);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            var model = _mapper.Map<UserProfile>(updateUserRequest);
            await _userManager.UpdateProfileAsync(model);
            var response = _mapper.Map<UpdateUserResponse>(model);

            return Ok(response);
        }

        /// <summary>
        /// Deletes user in hospital
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [Authorize(Roles = AuthRoles.ADMIN)]
        [HttpDelete]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 200)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUserAsync([FromQuery] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Id is null or empty");
            }

            var user = await _userManager.GetById(id);

            if (user == null)
            {
                return BadRequest("user not found");
            }

            return Ok();
        }
    }
}
