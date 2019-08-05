using System;
using SmartHospitalSystem.Core.Models;
using Microsoft.AspNetCore.Identity;
using SmartHospitalSystem.Core.Interfaces.Managers;

namespace SmartHospitalSystem.Core.Managers
{
    /// <summary>
    /// Authorization manager
    /// </summary>
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly IPasswordHasher<UserProfile> _passwordHasher;

        /// <summary>
        /// Constructor of Authorization manager
        /// </summary>
        /// <param name="passwordHasher"></param>
        public AuthorizationManager(IPasswordHasher<UserProfile> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Authorizing existing user
        /// </summary>
        /// <param name="loginModel">Model for authorization</param>
        /// <param name="profile">Existing user profile</param>
        /// <returns></returns>
        public UserProfile Authenticate(UserLoginModel loginModel, UserProfile profile)
        {
            var userNameMatches = string.Equals(loginModel.Username, profile.Login, StringComparison.InvariantCultureIgnoreCase);
            var passwordMatches = _passwordHasher.VerifyHashedPassword(profile, profile.Password, loginModel.Password) == PasswordVerificationResult.Success;

            if (userNameMatches && passwordMatches)
            {
                return profile;
            }

            return null;
        }
    }
}
