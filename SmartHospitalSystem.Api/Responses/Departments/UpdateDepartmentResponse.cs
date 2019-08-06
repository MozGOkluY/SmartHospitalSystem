using System;
using System.Runtime.Serialization;

namespace SmartHospitalSystem.Api.Responses
{
    /// <summary>
    /// Update department response
    /// </summary>
    [DataContract]
    public class UpdateDepartmentResponse
    {
        /// <summary>
        /// Gets or set department name
        /// </summary>
        [DataMember]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or set description
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets department id
        /// </summary>
        [DataMember]
        public string DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets created date
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }
    }
}
