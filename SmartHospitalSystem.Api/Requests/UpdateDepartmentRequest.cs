using System.Runtime.Serialization;

namespace SmartHospitalSystem.Core.Models
{
    /// <summary>
    /// Update department request
    /// </summary>
    [DataContract]
    public class UpdateDepartmentRequest
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
    }
}
