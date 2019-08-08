using System.Collections.Generic;

namespace SmartHospitalSystem.Core.Models
{
    /// <summary>
    /// Patient model
    /// </summary>
    public class PatientModel
    {
        /// <summary>
        /// User data
        /// </summary>
        public UserProfile UserData { get; set; }

        /// <summary>
        /// Visits list
        /// </summary>
        public List<VisitModel> Visits { get; set; }
    }
}
