using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using SmartHospitalSystem.Core.Enums;

namespace SmartHospitalSystem.Core.Models
{
    /// <summary>
    /// Visit model
    /// </summary>
    public class VisitModel
    {
        public VisitModel()
        {
            CreatedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or set user Id
        /// </summary>
        [BsonElement("userProfileId")]
        public string UserProfileId { get; set; }

        /// <summary>
        /// Gets or set treatment id
        /// </summary>
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonElement("visitId")]
        public string VisitId { get; set; }

        /// <summary>
        /// Gets or set bed id
        /// </summary>
        [BsonElement("bedName")]
        public string BedId { get; set; }

        /// <summary>
        /// Gets or set patient symptoms
        /// </summary>
        [BsonElement("symptoms")]
        public string Symptoms { get; set; }


        /// <summary>
        /// Gets or set patient allergies
        /// </summary>
        [BsonElement("allergies")]
        public string Allergies { get; set; }

        /// <summary>
        /// Gets or set patient allergies
        /// </summary>
        [BsonElement("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or set patient diagnosis
        /// </summary>
        [BsonElement("diagnosis")]
        public string Diagnosis { get; set; }

        /// <summary>
        /// Gets or set patient diagnosis
        /// </summary>
        [BsonElement("treatmentHistory")]
        public List<string> TreatmentHistory { get; set; }

        /// <summary>
        /// Gets or set patient status
        /// </summary>
        [BsonElement("status")]
        public HospitalStatus Status { get; set; }

        /// <summary>
        /// Gets or set treatment type
        /// </summary>
        [BsonElement("treatmentType")]
        public TreatmentType TreatmentType { get; set; }

        /// <summary>
        /// Date of unit creation
        /// </summary>
        [BsonElement("createdDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedDate { get; set; }   // date and time
    }
}
