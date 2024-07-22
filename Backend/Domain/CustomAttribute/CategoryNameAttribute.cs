
using System.ComponentModel.DataAnnotations;

namespace Domain.CustomAttribute
{
    public class CategoryNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string[] prohibitedСategories = ["Tobacco products", "Animal", "Animals", "Drugs", "Drug", "Weapons", "Weapon", "Tobacco"];

            var categoryName = value as string;

            if (categoryName != null)
            {
                foreach (var category in prohibitedСategories)
                {
                    if (category.Contains(categoryName))
                    {
                        new ValidationResult("This category isn`t available");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
