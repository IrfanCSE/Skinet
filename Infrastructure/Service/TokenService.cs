using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Core.Entities.Identity;
using Core.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Service {
    public class TokenService : ITokenService {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService (IConfiguration _config) {
            this._config = _config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }

        public string CreateToken (AppUser user) {
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName,user.DisplayName)
            };

            var creds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);
            
            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = creds,
                Issuer = _config["Token:Issuer"],
                Expires = DateTime.Now.AddDays(7)
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}