﻿using System;
using System.Runtime.Serialization;

namespace SmartHospitalSystem.Api.Requests
{
    /// <summary>
    /// Create department request
    /// </summary>
    [DataContract]
    public class CreateDepartmentRequest
    {
        /// <summary>
        /// Gets or set department id
        /// </summary>
        [DataMember]
        public string DepartmentId { get; set; }

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
        /// Gets or set description
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }
    }
}
