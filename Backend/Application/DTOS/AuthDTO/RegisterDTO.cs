using Application.DTOS.Customer;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOS.AuthDTO
{
    public class RegisterDTO
    {
        public int UserId { get; set; }
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;     
        public CustomerDTO Customer { get; init; }= new CustomerDTO();
       
        public string Role { get; init; } = SD.Customer;
    }
}
