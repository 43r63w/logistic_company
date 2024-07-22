using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Domain.CustomAttribute
{
    public class PhotoFormat : ValidationAttribute
    {
        private readonly string[] _photoFormat;

        public PhotoFormat(string[] photoFormat)
        {
            _photoFormat = photoFormat;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                var getFormat = Path.GetExtension(file.FileName);

                if (string.IsNullOrWhiteSpace(getFormat))
                {
                    foreach (var format in _photoFormat)
                    {
                        if (!format.Contains(getFormat))
                        {
                            new ValidationResult("Format photo isn`t supported");

                        }
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
