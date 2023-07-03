using AlphaKids.Infrastructure.Security;
using Microsoft.Extensions.Options;

namespace AlphaKids.WebApi.OptionsConfig;

public class JwtOptionsConfig : IConfigureOptions<JwtOptions>
{
    private const string JwtSectionName = "Jwt";
    IConfiguration configuration;

    public JwtOptionsConfig(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        configuration.GetSection(JwtSectionName).Bind(options);
    }
}
