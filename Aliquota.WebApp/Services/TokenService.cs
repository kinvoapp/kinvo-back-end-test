using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aliquota.Domain.Entities;
using Aliquota.WebApp.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Aliquota.WebApp.Services
{
    public class TokenService
    {
        private readonly IOptions<AppConfig> appConfig;

        public TokenService(IOptions<AppConfig> appConfig)
        {
            this.appConfig = appConfig;
        }

        public List<Claim> GetClaims(User user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
            };
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetClaims(user)),
                Expires = DateTime.Now + appConfig.Value.TokenValidityTime,
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(appConfig.Value.TokenSecretKey),
                    SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}