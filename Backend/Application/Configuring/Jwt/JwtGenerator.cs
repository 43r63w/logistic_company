using Application.DTOS;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Configuring.Jwt
{
    public class JwtGenerator
    {
        private readonly IConfiguration _configuration;
        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GenerateToken(string email, string role)
        {

            
            var claims = new List<Claim>
            {
                new Claim("Email", email),
                new Claim("Role", role),
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

            var signToken = new SigningCredentials(key: key, algorithm: SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            claims: claims,
            issuer: "localhost",
            audience: "localhost",
            signingCredentials: signToken,
            expires: DateTime.Now.AddDays(1));

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }


}
