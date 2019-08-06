using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartHospitalSystem.Api.Responses
{
    /// <summary>
    /// Departments response
    /// </summary>
    [DataContract]
    public class DepartmentsResponse
    {
        /// <summary>
        /// Gets or sets departments
        /// </summary>
        public List<DepartmentResponse> Departments { get; set; }
    }
}
