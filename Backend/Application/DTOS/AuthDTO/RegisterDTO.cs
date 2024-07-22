using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOS.AuthDTO
{
    public class RegisterDTO
    {
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;
        [Compare(nameof(Password))]
        public string RepeatPassword { get; init; } = null!;
        
        public int? CustomerId { get; init; }
        
        public string Role { get; init; } = SD.Customer;
    }
}
