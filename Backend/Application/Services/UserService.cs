using Application.Configuring.Exceptions;
using Application.Configuring.Hasher;
using Application.Configuring.Jwt;
using Application.Configuring.Validators;
using Application.DTOS;
using Application.DTOS.AuthDTO;
using Application.DTOS.Customer;
using Application.IServices;
using Domain;
using Domain.DbSets;
using FluentValidation;
using Infrastructure.IGenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication.PgOutput.Messages;
using System.Buffers.Text;
using System.Security.Cryptography;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtGenerator _jwtGenerator;

        public UserService(
            IUnitOfWork unitOfWork,
            JwtGenerator jwtGenerator)
        {
            _unitOfWork = unitOfWork;
            _jwtGenerator = jwtGenerator;
        }


        public async Task<GeneralResponseDTO> RegisterAsync(RegisterDTO registerDto)
        {
            var validation = new UserValidator(_unitOfWork);
            var result = await validation.ValidateAsync(registerDto);

            if (!result.IsValid)
                throw new ConflictException("Email already taken");
            
            
            var newUser = new User
            {
                Email = registerDto.Email,
                Password = PasswordHash.HashPassword(registerDto.Password),
                CustomerId = registerDto.CustomerId,
                Role = registerDto.Role,
                IsHaveBan = false,
            };

            if (string.IsNullOrWhiteSpace(registerDto.Role) || registerDto.Role.Contains("string"))
                newUser.Role = SD.Customer;

            await _unitOfWork.UserRepository.CreateAsync(newUser);
            await _unitOfWork.CommitAsync();

            return new GeneralResponseDTO
            {
                IsSucceded = true,
                Message = $"{registerDto.Email},registered"
            };
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDto)
        {
            var validation = new LoginValidator(_unitOfWork);
            var result = await validation.ValidateAsync(loginDto);
            
            if (!result.IsValid)
            {
                throw new BadRequestException("Something went wrong", result.ToDictionary());
            }

            var fromDb = await _unitOfWork.UserRepository.GetAsync(e => e.Email.ToLower() == loginDto.Email.ToLower(),
            includeOptions: "Customer,Employee");

            return new LoginResponseDTO
            {
                Token = _jwtGenerator.GenerateToken(fromDb.Email, fromDb.Role),
                PasswordToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32))
            };


        }
        public async Task<GeneralResponseDTO> ChangePasswordAsync(UserDTO userDto)
        {
            throw new NotImplementedException();
        }
        public async Task<CustomerDTO> CheckProfileAsync(string email)
        {
            var getFromDb = await _unitOfWork.UserRepository.GetAsync(e => e.Email.ToLower() == email.ToLower(), includeOptions: "Customer");

            if (getFromDb != null)
            {
                var infoAboutCustomer = new CustomerDTO
                {
                    Id = getFromDb.Id,
                    CompanyName = getFromDb.Customer.CompanyName,
                    ContactName = getFromDb.Customer.ContactName,
                    ContactTitle = getFromDb.Customer.ContactTitle,
                    Address = getFromDb.Customer.Address,
                    PostalCode = getFromDb.Customer.PostalCode,
                    City = getFromDb.Customer.City,
                    Country = getFromDb.Customer.Country,
                    PhoneNumber = getFromDb.Customer.PhoneNumber,
                };

                return infoAboutCustomer;
            }

            throw new NotFoundException("Customer isn`t exists", $"{email}");
        }
        public async Task<GeneralResponseDTO> BanCustomerAsync(string email)
        {
            var getFromDb = await _unitOfWork.UserRepository.GetAsync();

            if (getFromDb == null)
            {
                throw new NotFoundException(key: $"{email}");
            }

            var restrict = new Restriction
            {
                UserId = getFromDb.Id,
                BanType = SD.TemporaryBan,
                RestrictionDetail = "Make many order and then cancelled it",
                ExpiresDateRestriction = DateTimeOffset.UtcNow.AddDays(7)
            };

            await _unitOfWork.RestrictRepository.CreateAsync(restrict);
            await _unitOfWork.CommitAsync();

            return new GeneralResponseDTO
            {
                IsSucceded = true,
                Message = $"{getFromDb.Email} was banned"
            };
        }
        public async Task<GeneralResponseDTO> UnbanCustomerAsync(int id)
        {
            var getCustomer = await _unitOfWork.RestrictRepository.GetAsync(e => e.Id == id, includeOptions: "User");
            if (getCustomer != null)
            {
                await _unitOfWork.RestrictRepository.DeleteAsync(getCustomer);
                await _unitOfWork.CommitAsync();
            }

            return new GeneralResponseDTO
            {
                IsSucceded = true,
                Message = $"{getCustomer.User.Email} was unbanned"
            };
            
        }

    }
}
