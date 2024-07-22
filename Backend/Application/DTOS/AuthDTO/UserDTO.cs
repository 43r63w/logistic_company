using System.ComponentModel.DataAnnotations;

namespace Application.DTOS
{
    public class UserDTO
    {
        public string Email { get; set; }= null!;
        public string Password { get; set; }= null!;
        [Compare(nameof(Password))]
        public string RepeatPassword { get; set; } = null!;
        public string Role { get; set; }= null!;
    }
}
