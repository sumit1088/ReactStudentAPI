using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StudentForm.Models
{  

    public class OptionalEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var email = value as string;

            // Allow null or empty strings
            if (string.IsNullOrWhiteSpace(email))
                return ValidationResult.Success;

            // Basic email format check
            var isValid = Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);

            return isValid
                ? ValidationResult.Success
                : new ValidationResult("Invalid email address");
        }
    }

}
