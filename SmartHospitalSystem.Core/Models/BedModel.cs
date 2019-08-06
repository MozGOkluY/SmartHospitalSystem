using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartHospitalSystem.Core.Models
{
    /// <summary>
    /// Bed model
    /// </summary>
    public class BedModel
    {
        public BedModel()
        {
            CreatedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or set department Id
        /// </summary>
        [BsonElement("departmentId")]
        public string DepartmentId { get; set; }

        /// <summary>
        /// Gets or set bed id
        /// </summary>
        [BsonElement("bedId")]
        public string BedId { get; set; }

        /// <summary>
        /// Gets or set bed name
        /// </summary>
        [BsonElement("bedName")]
        public string BedName { get; set; }

        /// <summary>
        /// Gets or set patient id
        /// </summary>
        [BsonElement("patientId")]
        public string PatientId { get; set; }

        /// <summary>
        /// Date of unit creation
        /// </summary>
        [BsonElement("createdDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedDate { get; set; }   // date and time
    }
}
