using System.ComponentModel.DataAnnotations;

namespace PersonalCare.Application.Validations
{
    public class ObrigatorioAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value?.ToString()) || value.ToString().Equals("0"))
                return new ValidationResult($"O campo '{validationContext.DisplayName}' é obrigatório.");

            return ValidationResult.Success;
        }
    }
}
