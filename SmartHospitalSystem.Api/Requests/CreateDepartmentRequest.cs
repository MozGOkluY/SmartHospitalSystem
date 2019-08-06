using System.Runtime.Serialization;

namespace SmartHospitalSystem.Core.Models
{
    /// <summary>
    /// Create department request
    /// </summary>
    [DataContract]
    public class CreateDepartmentRequest
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
    }
}
