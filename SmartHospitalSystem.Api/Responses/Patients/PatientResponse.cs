using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartHospitalSystem.Api.Responses
{
    /// <summary>
    /// Create patient response
    /// </summary>
    [DataContract]
    public class PatientResponse
    {
        /// <summary>
        /// Gets or sets user data
        /// </summary>
        [DataMember]
        public UserResponse UserData { get; set; }

        /// <summary>
        /// Gets or sets visits
        /// </summary>
        [DataMember]
        public List<VisitReponse> Visits { get; set; }
    }
}
