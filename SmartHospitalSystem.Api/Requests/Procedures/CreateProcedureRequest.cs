using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SmartHospitalSystem.Api.Requests
{
    /// <summary>
    /// Create bed request
    /// </summary>
    [DataContract]
    public class CreateProcedureRequest
    {
        /// <summary>
        /// Gets or sets procedure name
        /// </summary>
        [DataMember]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Invalid procedure name")]
        public string ProcedureName { get; set; }

        /// <summary>
        /// Gets or sets duration
        /// </summary>
        [DataMember]
        [Required]
        public int Duration { get; set; }
    }
}
