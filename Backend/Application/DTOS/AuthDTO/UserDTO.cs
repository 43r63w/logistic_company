using Application.DTOS.Customer;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOS
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }= null!;


        public CustomerDTO? CustomerDTO { get; set; } 


        public string Role { get; set; }= null!;
    }
}
