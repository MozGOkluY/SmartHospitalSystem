using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SmartHospitalSystem.Core.Interfaces.Managers;
using SmartHospitalSystem.Core.Interfaces.Repositories;
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Core.Managers
{
    /// <summary>
    /// Managing of users and business logic for them
    /// </summary>
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<UserProfile> _passwordHasher;

        /// <summary>
        /// Constructor of UserManager
        /// </summary>
        /// <param name="userRepository"></param>
        public UserManager(IUserRepository userRepository, IPasswordHasher<UserProfile> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Returns model of user by id
        /// </summary>
        /// <param name="id">Id of existing user</param>
        /// <returns></returns>
        public Task<UserProfile> GetById(string id)
        {
            return _userRepository.FindAsync(id);
        }

        /// <summary>
        /// Returns model of user by user login
        /// </summary>
        /// <param name="login">Login of existing user</param>
        /// <returns></returns>
        public Task<UserProfile> GetByLogin(string login)
        {
            return _userRepository.FindByLogin(login);
        }

        /// <summary>
        /// Returns model of user by email
        /// </summary>
        /// <param name="email">Email of existing user</param>
        /// <returns></returns>
        public Task<UserProfile> GetByEmail(string email)
        {
            return _userRepository.FindByEmail(email);
        }

        /// <summary>
        /// Returns all existing shows in DB
        /// </summary>
        /// <returns></returns>
        public Task<List<UserProfile>> GetAllUsers()
        {
            return _userRepository.SelectAllAsync();
        }

        /// <summary>
        /// Inserts new user in Db
        /// </summary>
        /// <param name="userProfile">Model of user that will be inserted</param>
        /// <returns></returns>
        public Task InsertProfileAsync(UserProfile userProfile)
        {
            var hasPassowrd = _passwordHasher.HashPassword(userProfile, userProfile.Password);
            userProfile.Password = hasPassowrd;
            return _userRepository.InsertAsync(userProfile);
        }

        /// <summary>
        /// Updates existing user in Db
        /// </summary>
        /// <param name="userProfile">Model of user that will be updated</param>
        /// <returns></returns>
        public Task<bool> UpdateProfileAsync(UserProfile userProfile)
        {
            return _userRepository.ReplaceByIdAsync(userProfile.Id, userProfile);
        }

        /// <summary>
        /// Deletes existing user in Db
        /// </summary>
        /// <param name="id">Id of user that will be deleted</param>
        /// <returns></returns>
        public Task<bool> DeleteProfileAsync(string id)
        {
            return _userRepository.DeleteByIdAsync(id);
        }
    }
}
