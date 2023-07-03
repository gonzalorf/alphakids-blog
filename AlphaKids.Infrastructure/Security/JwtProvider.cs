using AlphaKids.Application.Common.Services;
using AlphaKids.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlphaKids.Infrastructure.Security;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions jwtOptions;

    public JwtProvider(IOptions<JwtOptions> jwtOptions)
    {
        this.jwtOptions = jwtOptions.Value;
    }

    public string GetJwt(User user)
    {
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            , new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtOptions.SecurityKey)),
            SecurityAlgorithms.HmacSha256
            );

        var jwt = new JwtSecurityToken(
            jwtOptions.Issuer
            , jwtOptions.Audience
            , claims
            , null
            , DateTime.UtcNow.AddDays(1)
            , signingCredentials
            );

        var jwtValue = new JwtSecurityTokenHandler().WriteToken(jwt);

        return jwtValue;
    }
}
