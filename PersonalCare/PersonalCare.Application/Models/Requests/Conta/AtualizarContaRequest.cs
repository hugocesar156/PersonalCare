using PersonalCare.Application.Validations;
using System.ComponentModel.DataAnnotations;

namespace PersonalCare.Application.Models.Requests.Conta
{
    public class AtualizarContaRequest
    {
        [Obrigatorio]
        public int Id { get; set; }

        [Obrigatorio, TamanhoMaximo(50)]
        public string Nome { get; set; }

        [Obrigatorio, EmailAddress, TamanhoMaximo(50)]
        public string Email { get; set; }

        [Obrigatorio, Cpf]
        public string Cpf { get; set; }

        public decimal? Altura { get; set; }

        [TamanhoMaximo(1)]
        public string? Biotipo { get; set; }

        [Obrigatorio, IdadeMinima(14)]
        public DateTime DataNascimento { get; set; }
    }
}
