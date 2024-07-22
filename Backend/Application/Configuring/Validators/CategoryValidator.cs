using Application.DTOS.Category;
using FluentValidation;
using Infrastructure.IGenericRepository;

namespace Application.Configuring.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDTO>
    {
        private readonly string[] _prohibitedsCategory = ["Tobacco products", "Animal", "Animals", "Drugs", "Drug", "Weapons", "Weapon", "Tobacco"];

        private readonly IUnitOfWork _unitOfWork;

        public CategoryValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(e => e.Name)
                .NotEmpty()
                .Must(name => !IsProhibitedCategory(name))
                .WithMessage($"The category is prohibited.")
                .MustAsync(async (categoryName, CancellationToken) => !await IsExistsCategoryName(categoryName))
                .WithMessage("Category with this name exsists");
        }

        private bool IsProhibitedCategory(string name) => _prohibitedsCategory.Contains(name.ToLower());

        private async Task<bool> IsExistsCategoryName(
            string name,
            CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.CategoryRepository.IsExistsAsync(name);
        }
     
    }


}
