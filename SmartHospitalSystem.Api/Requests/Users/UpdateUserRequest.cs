using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SmartHospitalSystem.Core.Enums;

namespace SmartHospitalSystem.Api.Requests
{
    /// <summary>
    /// Update user request
    /// </summary>
    [DataContract]
    public class UpdateUserRequest
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Login
        /// </summary>
        [DataMember]
        public string Login { get; set; }

        /// <summary>
        /// Firstname
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Role of user
        /// </summary>
        [DataMember]
        public List<UserRoleEnum> Roles { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// MaritalStatus
        /// </summary>
        [DataMember]
        public MaritalStatusEnum MaritalStatus { get; set; }

        /// <summary>
        /// Blood group
        /// </summary>
        [DataMember]
        public BloodGroup BloodGroup { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        [DataMember]
        public string Image { get; set; }

        /// <summary>
        /// Date of user creation
        /// </summary>
        [DataMember]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Date of user creation
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }
    }
}
