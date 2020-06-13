using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APBD_CAMPAIGN.Services
{
    public class AuthService : IAuthService
    {

        private IConfiguration _configuration { get; set; }

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AuthTokens GenerateTokens()
        {
            var claims = new[]
          {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "client"),
                new Claim(ClaimTypes.Role, "client")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_SECRET"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken
           (
               issuer: "DODATKOWY_PROJEKT_ISSUER",
               audience: "DODATKOWY_PROJEKT_AUDIENCE",
               claims: claims,
               expires: DateTime.Now.AddMinutes(60),
               signingCredentials: credentials
           );

            var refreshToken = Guid.NewGuid();

            return new AuthTokens
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken.ToString()
            };
        }
    }
}
