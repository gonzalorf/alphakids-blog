using AlphaKids.Infrastructure.Security;
using Microsoft.Extensions.Options;

namespace AlphaKids.WebApi.OptionsConfig
{
    public class JwtOptionsConfig : IConfigureOptions<JwtOptions>
    {
        IConfiguration configuration;

        public JwtOptionsConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            configuration.GetSection("Jwt").Bind(options);
        }
    }
}
