using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartHospitalSystem.Api.Responses
{
    /// <summary>
    /// Procedure response
    /// </summary>
    [DataContract]
    public class ProceduresResponse
    {
        /// <summary>
        /// Gets or sets procedures
        /// </summary>
        [DataMember]
        public List<ProcedureResponse> Procedures { get; set; }
    }
}
