using Application.DTOS.Product;
using Domain.DbSets;
using FluentValidation;
using Infrastructure.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configuring.Validators
{
    public class ProductValidator : AbstractValidator<CreateProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
            RuleFor(e => e.Name)
                .NotEmpty()
                .NotNull()
                .MustAsync(async (name, CancellationToken) => !await IsExistsAsync(name))
                .WithMessage("Product with this name is exists");


            RuleFor(e => e.Price)
                .NotEmpty()
                .NotNull()
                .Must(price => price > 0)
                .WithMessage("Price for product must greater then 0");

            RuleFor(e => e.CategoryName)
                .NotEmpty()
                .NotNull()
                .WithMessage("This field must fill");


        }

        private async Task<bool> IsExistsAsync(string name)
        {
            return await _unitOfWork.ProductRepository.NameExistsAsync(name);
        }
        
        private async Task<bool> IdIsExistsAsync(int id)
        {
            return await _unitOfWork.ProductRepository.FindByIdAsync(id);
        }

        
        

    }
}
