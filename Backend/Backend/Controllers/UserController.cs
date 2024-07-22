using Application.DTOS;
using Application.DTOS.AuthDTO;
using Application.DTOS.Customer;
using Application.IServices;
using AutoMapper.Configuration.Annotations;
using Infrastructure.IGenericRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

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

        [HttpPost("Register")]
        public async Task<ActionResult<GeneralResponseDTO>> Register(RegisterDTO registerDto)
        {
            var result = await _userService.RegisterAsync(registerDto);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<GeneralResponseDTO>> Login(LoginDTO loginDto)
        {
            var result = await _userService.LoginAsync(loginDto);
            _contextAccessor.HttpContext.Response.Cookies.Append("token", result.Token);
            return Ok(result);
        }
        [HttpGet("GetInfoAboutProfileCustomer")]
        [Authorize]
        public async Task<ActionResult<CustomerDTO>> GetInfoAboutProfileCustomer(string email)
        {
            var result = await _userService.CheckProfileAsync(email);
            return Ok(result);
        }

        [HttpPost("BanCustomer")]
        [Authorize(policy: "EmployeePolicy")]
        public async Task<ActionResult<GeneralResponseDTO>> BanCustomer(string email)
        {
            var result = await _userService.BanCustomerAsync(email);
            return Ok(result);
        }
        
        [HttpPost("UnbanCustomer")]
        [Authorize(policy: "EmployeePolicy")]
        public async Task<ActionResult<GeneralResponseDTO>> UnbanCustomer(int id)
        {
            var result = await _userService.UnbanCustomerAsync(id);
            return Ok(result);
        }
    }
}
