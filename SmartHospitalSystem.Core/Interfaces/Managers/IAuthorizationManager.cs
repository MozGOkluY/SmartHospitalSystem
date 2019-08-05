
using SmartHospitalSystem.Core.Models;

namespace SmartHospitalSystem.Core.Interfaces.Managers
{
    /// <summary>
    /// Authorization manager
    /// </summary>
    public interface IAuthorizationManager
    {
        /// <summary>
        /// Authorizing existing user
        /// </summary>
        /// <param name="loginModel">Model for authorization</param>
        /// <param name="profile">Existing user profile</param>
        /// <returns></returns>
        UserProfile Authenticate(UserLoginModel loginModel, UserProfile profile);
    }
}
