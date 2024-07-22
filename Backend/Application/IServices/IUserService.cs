using Application.DTOS;
using Application.DTOS.AuthDTO;
using Application.DTOS.Customer;
using Domain.DbSets;

namespace Application.IServices
{
    public interface IUserService
    {
        Task<GeneralResponseDTO> RegisterAsync(RegisterDTO registerDto);
        
        Task<LoginResponseDTO> LoginAsync(LoginDTO loginDto);

        Task<GeneralResponseDTO> ChangePasswordAsync(UserDTO userDto);

        Task<CustomerDTO> CheckProfileAsync(string email);
        
        Task<GeneralResponseDTO> BanCustomerAsync(string email);
        
        Task<GeneralResponseDTO> UnbanCustomerAsync(int id);
    }
}
