using Application.DTOS;
using Application.DTOS.AuthDTO;
using Application.DTOS.Customer;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserController(IUserService userService,
            IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
        }
        [HttpPost("register-user")]
        public async Task<ActionResult<GeneralResponseDTO>> RegisterAsync(RegisterDTO registerDto)
        {
            var result = await _userService.RegisterAsync(registerDto);
            return Ok(result);
        }
        [HttpPost("login-user")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginDTO loginDto)
        {
            var result = await _userService.LoginAsync(loginDto);
            return Ok(result);
        }
        [HttpGet("get-info-about-customer")]
        //[Authorize]
        public async Task<ActionResult<CustomerDTO>> GetInfoAboutProfileCustomer(string email)
        {
            var result = await _userService.CheckProfileAsync(email);
            return Ok(result);
        }

        [HttpPost("ban-customer")]
        [Authorize(policy: "EmployeePolicy")]
        public async Task<ActionResult<GeneralResponseDTO>> BanCustomer(string email)
        {
            var result = await _userService.BanCustomerAsync(email);
            return Ok(result);
        }
        
        [HttpPost("u")]
        [Authorize(policy: "EmployeePolicy")]
        public async Task<ActionResult<GeneralResponseDTO>> UnbanCustomer(int id)
        {
            var result = await _userService.UnbanCustomerAsync(id);
            return Ok(result);
        }
    }
}
