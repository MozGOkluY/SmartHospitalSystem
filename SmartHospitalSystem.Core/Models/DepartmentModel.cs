using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartHospitalSystem.Core.Models
{
    /// <summary>
    /// Department model
    /// </summary>
    public class DepartmentModel
    {
        public DepartmentModel()
        {
            CreatedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or set department id
        /// </summary>
        [BsonElement("departmentId")]
        public string DepartmentId { get; set; }

        /// <summary>
        /// Gets or set department name
        /// </summary>
        [BsonElement("departmentName")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or set description
        /// </summary>
        [BsonElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Date of unit creation
        /// </summary>
        [BsonElement("createdDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedDate { get; set; }   // date and time
    }
}
