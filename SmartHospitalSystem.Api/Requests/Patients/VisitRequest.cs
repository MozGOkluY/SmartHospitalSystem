using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SmartHospitalSystem.Core.Enums;

namespace SmartHospitalSystem.Api.Responses
{
    /// <summary>
    /// Create visit response
    /// </summary>
    [DataContract]
    public class VisitRequest
    {
        /// <summary>
        /// Gets or set user Id
        /// </summary>
        [DataMember]
        public string UserProfileId { get; set; }

        /// <summary>
        /// Gets or set bed id
        /// </summary>
        [DataMember]
        public string BedId { get; set; }

        /// <summary>
        /// Gets or set patient symptoms
        /// </summary>
        [DataMember]
        public string Symptoms { get; set; }

        /// <summary>
        /// Gets or set patient allergies
        /// </summary>
        [DataMember]
        public string Allergies { get; set; }

        /// <summary>
        /// Gets or set patient allergies
        /// </summary>
        [DataMember]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or set patient status
        /// </summary>
        [DataMember]
        public HospitalStatus Status { get; set; }

        /// <summary>
        /// Gets or set treatment type
        /// </summary>
        [DataMember]
        public TreatmentType TreatmentType { get; set; }

        /// <summary>
        /// Date of unit creation
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }   // date and time
    }
}
