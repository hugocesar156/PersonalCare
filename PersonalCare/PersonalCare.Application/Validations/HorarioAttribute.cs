using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PersonalCare.Application.Validations
{
    public class HorarioAttribute : ValidationAttribute
    {
        private readonly string _propHoraFinal;

        public HorarioAttribute(string propHoraFinal = "")
        {
            _propHoraFinal = propHoraFinal;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var horaInicial = value?.ToString() ?? string.Empty;

            if (Regex.IsMatch(horaInicial, @"^([01][0-9]|2[0-3]):([0-5][0-9])$"))
            {
                if (!string.IsNullOrEmpty(_propHoraFinal))
                {
                    var horaFinal = validationContext.ObjectType.GetProperty(_propHoraFinal)?.GetValue(validationContext.ObjectInstance)?.ToString() ?? string.Empty;

                    if (Regex.IsMatch(horaFinal, @"^([01][0-9]|2[0-3]):([0-5][0-9])$"))
                    {
                        if (int.Parse(horaInicial.Replace(":", "")) < int.Parse(horaFinal.Replace(":", "")))
                        {
                            return ValidationResult.Success;
                        }

                        return new ValidationResult("O horário inicial deve ser anterior so horário final.");
                    }

                    return new ValidationResult("Fomato do horário final inválido.");
                }
            }

            return new ValidationResult("Fomato do horário inicial inválido.");
        }
    }
}
