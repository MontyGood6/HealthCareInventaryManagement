using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Healthcare.InventoryManagement.Domain.Entity; // Ensure this is present

namespace Healthcare.InventoryManagement.Application.Services
{
    public class JwtTokenServices
    {
        private readonly IConfiguration _config;

        public JwtTokenServices(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(Healthcare.InventoryManagement.Domain.Entity.User user) // Fully qualify 'User'
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                // Fix: Use user.Role.Name or user.UserRoles.First().Role.Name if Role is a complex type
                new Claim(ClaimTypes.Role, user.Role != null ? user.Role.Role.Name : string.Empty)
            };

            var key = new SymmetricSecurityKey(     
                Encoding.UTF8.GetBytes(_config["JwtSettings:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(
                    Convert.ToDouble(_config["JwtSettings:DurationInMinutes"])
                ),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
