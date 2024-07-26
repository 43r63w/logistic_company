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


        public string GenerateToken(UserDTO userDTO)
        {        

            var claims = new List<Claim>
            {        
                new Claim("UserId",userDTO.Id.ToString()),
                new Claim("Email", userDTO.Email),
                new Claim("Role",  userDTO.Role),
                new Claim("CompanyName",userDTO.CustomerDTO.CompanyName),
                new Claim("ContactName",userDTO.CustomerDTO.ContactName),
                new Claim("ContactTitle",userDTO.CustomerDTO.ContactTitle),
                new Claim("Address",userDTO.CustomerDTO.Address),
                new Claim("PostalCode",userDTO.CustomerDTO.PostalCode),
                new Claim("City",userDTO.CustomerDTO.City),
                new Claim("Country",userDTO.CustomerDTO.Country),
                new Claim("PhoneNumber",userDTO.CustomerDTO.PhoneNumber),
               new Claim("CustomerId",userDTO.CustomerDTO.Id.ToString()),
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
