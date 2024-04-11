using System.ComponentModel.DataAnnotations;

namespace PersonalCare.Application.Validation
{
    public class IdadeMinimaAttribute : ValidationAttribute
    {
        private readonly int _anos;

        public IdadeMinimaAttribute(int anos)
        {
            _anos = anos;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContexst)
        {
            var data = Convert.ToDateTime(value);

            if ((DateTime.Now.Year - data.Year) < _anos)
                return new ValidationResult($"A idade mínima para o cadastro é de {_anos} anos.");

            return ValidationResult.Success;
        }
    }
}
