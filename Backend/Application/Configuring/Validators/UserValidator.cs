using Application.DTOS;
using Application.DTOS.AuthDTO;
using FluentValidation;
using FluentValidation.Validators;
using Infrastructure.IGenericRepository;
using System.Data;

namespace Application.Configuring.Validators
{

    public class UserValidator : AbstractValidator<RegisterDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(e => e.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull()
                .MustAsync(async (email, CancellationToken) => !await IsExistsAsync(email))
                .WithMessage("{Email} was exists");


            RuleFor(e => e.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(15);
        }


        private async Task<bool> IsExistsAsync(string email)
        {
            return await _unitOfWork.UserRepository.AnyAsync(e => e.Email.ToLower() == email.ToLower());
        }



    }
}
