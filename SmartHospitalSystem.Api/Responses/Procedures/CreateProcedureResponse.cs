using System;
using System.Runtime.Serialization;

namespace SmartHospitalSystem.Api.Responses
{
    /// <summary>
    /// Bed response
    /// </summary>
    [DataContract]
    public class CreateProcedureResponse
    {
        /// <summary>
        /// Gets or set user Id
        /// </summary>
        [DataMember]
        public string ProcedureId { get; set; }

        /// <summary>
        /// Gets or sets procedure name
        /// </summary>
        [DataMember]
        public string ProcedureName { get; set; }

        /// <summary>
        /// Gets or sets duration
        /// </summary>
        [DataMember]
        public int Duration { get; set; }

        /// <summary>
        /// Date of unit creation
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }
    }
}
