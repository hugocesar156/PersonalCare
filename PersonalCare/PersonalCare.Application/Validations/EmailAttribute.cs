using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace PersonalCare.Application.Validations
{
    public class EmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            try
            {
                _ = new MailAddress(value?.ToString() ?? "");
                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult("Formato de email inválido.");
            }
        }
    }
}
