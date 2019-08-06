using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartHospitalSystem.Api.Responses
{
    /// <summary>
    /// Beds response
    /// </summary>
    [DataContract]
    public class BedsResponse
    {
        /// <summary>
        /// Gets or sets beds
        /// </summary>
        public List<BedResponse> Beds { get; set; }
    }
}
