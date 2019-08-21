using System;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartHospitalSystem.Core.Models
{
    /// <summary>
    /// Procedure model
    /// </summary>
    public class ProcedureModel
    {
        public ProcedureModel()
        {
            CreatedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or set user Id
        /// </summary>
        [BsonElement("procedureId")]
        public string ProcedureId { get; set; }

        /// <summary>
        /// Gets or sets procedure name
        /// </summary>
        [BsonElement("procedureName")]
        public string ProcedureName { get; set; }

        /// <summary>
        /// Gets or sets duration
        /// </summary>
        [BsonElement("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Date of unit creation
        /// </summary>
        [BsonElement("createdDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedDate { get; set; }
    }
}
