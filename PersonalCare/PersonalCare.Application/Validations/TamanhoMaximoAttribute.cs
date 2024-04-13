using System.ComponentModel.DataAnnotations;

namespace PersonalCare.Application.Validations
{
    public class TamanhoMaximoAttribute : ValidationAttribute
    {
        private readonly int _valor;

        public TamanhoMaximoAttribute(int valor)
        {
            _valor = valor;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value?.ToString()?.Length > _valor)
                return new ValidationResult($"O tamanho máximo para o campo '{validationContext.DisplayName}' é de {_valor} caracteres.");

            return ValidationResult.Success;
        }
    }
}
