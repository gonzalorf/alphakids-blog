using AlphaKids.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AlphaKids.WebApi.OptionsConfig;

public class JwtBearerOptionsConfig : IConfigureNamedOptions<JwtBearerOptions>
{
    JwtOptions jwtOptions;

    public JwtBearerOptionsConfig(IOptions<JwtOptions> jwtOptions)
    {
        this.jwtOptions = jwtOptions.Value;
    }

    public void Configure(JwtBearerOptions options)
    {
        SetProperties(options);
    }

    public void Configure(string? name, JwtBearerOptions options)
    {
        SetProperties(options);
    }

    private void SetProperties(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions.SecurityKey))
        };
    }
}
