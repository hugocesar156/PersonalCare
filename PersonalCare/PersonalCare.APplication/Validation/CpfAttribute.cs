using System.ComponentModel.DataAnnotations;

namespace PersonalCare.Application.Validation
{
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (!ValidarCpf(value?.ToString() ?? ""))
                return new ValidationResult($"CPF informado inválido.");

            return ValidationResult.Success;
        }

        private bool ValidarCpf(string cpf)
        {
            if (cpf.Length != 11 || !VerificarDigitos(cpf))
            {
                return false;
            }

            int soma = 0;
            int resto;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }

            resto = soma % 11;

            if (resto < 2)
            {
                if (int.Parse(cpf[9].ToString()) != 0)
                {
                    return false;
                }
            }
            else
            {
                if (int.Parse(cpf[9].ToString()) != 11 - resto)
                {
                    return false;
                }
            }

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            }

            resto = soma % 11;

            if (resto < 2)
            {
                if (int.Parse(cpf[10].ToString()) != 0)
                {
                    return false;
                }
            }
            else
            {
                if (int.Parse(cpf[10].ToString()) != 11 - resto)
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerificarDigitos(string cpf)
        {
            foreach (char c in cpf)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            for (var i = 0; i < 10; i++)
            {
                if (cpf == string.Concat(Enumerable.Repeat(i.ToString(), 11)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
