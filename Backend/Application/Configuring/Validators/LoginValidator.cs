using Application.DTOS.AuthDTO;
using Domain;
using Domain.DbSets;
using FluentValidation;
using Infrastructure.IGenericRepository;

namespace Application.Configuring.Validators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(e => e.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull();

            RuleFor(e => e.Password)
                .NotEmpty()
                .NotNull();
            
            
            // RuleFor(e => e.Email)
            //     .MustAsync(async (email, CancellationToken) => !await CheckBanAsync(email))
            //     .WithMessage("You have a ban,If you have some questions,typing admin");
        }

        // private async Task<bool> CheckBanAsync(string email)
        // {
        //     var user = await _unitOfWork.UserRepository.GetAsync(e => e.Email == email);
        //     var result = await _unitOfWork.RestrictRepository.GetAsync(e => e.UserId == user.Id);
        //     return result.BanType.Contains(SD.TemporaryBan) || result.BanType.Contains(SD.PermanentBan);
        // }

    }
}
