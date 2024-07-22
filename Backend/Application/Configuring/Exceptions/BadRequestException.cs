using FluentValidation.Results;
using System.Globalization;

namespace Application.Configuring.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public IDictionary<string, string[]> Errors { get; set; }
        public BadRequestException(string? message, IDictionary<string, string[]>? errors = null) : base(message)
        {
            Errors = errors;
        }
    }
}