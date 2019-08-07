using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartHospitalSystem.Api.Responses
{
    /// <summary>
    /// Users response
    /// </summary>
    [DataContract]
    public class UsersResponse
    {
        /// <summary>
        /// Gets or sets users
        /// </summary>
        public List<UserResponse> Users { get; set; }
    }
}
