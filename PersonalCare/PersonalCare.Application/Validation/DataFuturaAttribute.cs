using System.ComponentModel.DataAnnotations;

namespace PersonalCare.Application.Validation
{
    public class DataFuturaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value?.ToString()).Date < DateTime.Now.Date)
                return new ValidationResult("Data informada inválida.");

            return ValidationResult.Success;
        }
    }
}
