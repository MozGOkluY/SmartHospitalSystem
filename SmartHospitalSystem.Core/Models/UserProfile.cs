using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using SmartHospitalSystem.Core.Enums;

namespace SmartHospitalSystem.Core.Models
{
    /// <summary>
    /// Full user model
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Constructor for profile
        /// </summary>
        public UserProfile()
        {
            CreatedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Unique id
        /// </summary>
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [Required(AllowEmptyStrings = false)]
        public string Id { get; set; }

        /// <summary>
        /// Login
        /// </summary>
        [BsonElement("login")]
        public string Login { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [BsonElement("password")]
        public string Password { get; set; }

        /// <summary>
        /// Firstname
        /// </summary>
        [BsonElement("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        [BsonElement("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Role of user
        /// </summary>
        [BsonElement("role")]
        public List<UserRoleEnum> Roles { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [BsonElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [BsonElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [BsonElement("city")]
        public string City { get; set; }

        /// <summary>
        /// MaritalStatus
        /// </summary>
        [BsonElement("maritalStatus")]
        public MaritalStatusEnum MaritalStatus { get; set; }

        /// <summary>
        /// Blood group
        /// </summary>
        [BsonElement("bloodGroup")]
        public BloodGroup BloodGroup { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        [BsonElement("image")]
        public string Image { get; set; }

        /// <summary>
        /// Date of user creation
        /// </summary>
        [BsonElement("birthDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime BirthDate { get; set; }   // date and time

        /// <summary>
        /// Date of user creation
        /// </summary>
        [BsonElement("createdDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedDate { get; set; }   // date and time
    }
}
