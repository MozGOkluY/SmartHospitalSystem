using System;

namespace SmartHospitalSystem.Api.Responses
{
    /// <summary>
    /// Token response
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// Get or sets user id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets token expires
        /// </summary>
        public DateTime TokenExpires { get; set; }

        /// <summary>
        /// Gets or sets token
        /// </summary>
        public string Token { get; set; }
    }
}
