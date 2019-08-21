using System;
using System.Runtime.Serialization;

namespace SmartHospitalSystem.Api.Requests
{
    /// <summary>
    /// Create bed request
    /// </summary>
    [DataContract]
    public class UpdateProcedureRequest
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
    }
}
