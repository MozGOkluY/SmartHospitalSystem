namespace SmartHospitalSystem.Core.Interfaces.Configurations
{
    /// <summary>
    /// Token configuration
    /// </summary>
    public interface ITokenConfiguration
    {
        /// <summary>
        /// Gets or sets secret
        /// </summary>
        string Secret { get; set; }

        /// <summary>
        /// Gets or sets issuer
        /// </summary>
        string Issuer { get; set; }

        /// <summary>
        /// Gets or sets aurdience
        /// </summary>
        string Audience { get; set; }

        /// <summary>
        /// Get or sets token expires time
        /// </summary>
        int TokenExpiresIn { get; set; }
    }
}
