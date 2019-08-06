namespace SmartHospitalSystem.Core.Constants
{
    /// <summary>
    /// Authentication roles.
    /// </summary>
    public static class AuthRoles
    {
        /// <summary>
        /// Admin role
        /// </summary>
        public const string ADMIN = "admin";

        /// <summary>
        /// Nurse role
        /// </summary>
        public const string NURSE = "nurse";

        /// <summary>
        /// Doctor role
        /// </summary>
        public const string DOCTOR = "doctor";

        /// <summary>
        /// Registry role
        /// </summary>
        public const string REGISTRY = "registry";

        /// <summary>
        /// Patient role
        /// </summary>
        public const string PATIENT = "patient";

        /// <summary>
        /// Mixed role
        /// </summary>
        public const string MIXED = "nurse, admin, registry";
    }
}