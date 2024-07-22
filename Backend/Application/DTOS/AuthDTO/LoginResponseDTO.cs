using Microsoft.IdentityModel.Tokens;

namespace Application.DTOS.AuthDTO
{
    public class LoginResponseDTO
    {
        public string Token { get; init; } = string.Empty;
        public string PasswordToken { get; init; } = string.Empty;
    }
}
