using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Domain.CustomAttribute
{
    public class MaxResulotion : ValidationAttribute
    {

        private readonly int _maxResulotion;

        public MaxResulotion(int maxResulotion)
        {
            _maxResulotion = maxResulotion;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                if (file.Length > (1_000_000 * _maxResulotion))
                {
                    new ValidationResult($"This photo must be {_maxResulotion}MB");
                }
            }

            return ValidationResult.Success;

        }
    }
}
