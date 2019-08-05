using Microsoft.Extensions.Configuration;
using SmartHospitalSystem.Core.Interfaces.Configurations;

namespace SmartHospitalSystem.Core.Configurations
{
    /// <inheritdoc />
    public class TokenConfiguration : ITokenConfiguration
    {
        /// <summary>
        /// Constructor with parameters for configuration
        /// </summary>
        /// <param name="configuration"></param>
        public TokenConfiguration(IConfiguration configuration)
        {
            IConfigurationSection section = configuration?.GetSection("Token");

            Secret = section.GetValue<string>(nameof(Secret));
            Issuer = section.GetValue<string>(nameof(Issuer));
            Audience = section.GetValue<string>(nameof(Audience));
            TokenExpiresIn = section.GetValue<int>(nameof(TokenExpiresIn));

        }

        /// <inheritdoc />
        public string Secret { get; set; }

        /// <inheritdoc />
        public string Issuer { get; set; }

        /// <inheritdoc />
        public string Audience { get; set; }

        /// <inheritdoc />
        public int TokenExpiresIn { get; set; }
    }
}
