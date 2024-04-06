using PersonalCare.Application.Validation;

namespace PersonalCare.Application.Models.Requests.Conta
{
    public class InserirContaRequest
    {
        [Obrigatorio, TamanhoMaximo(50)]
        public string Nome { get; set; }

        [Obrigatorio, Email, TamanhoMaximo(50)]
        public string Email { get; set; }

        [Obrigatorio, Cpf]
        public string Cpf { get; set; }

        public decimal? Altura { get; set; }

        [TamanhoMaximo(1)]
        public string? Biotipo { get; set; }

        [Obrigatorio, IdadeMinima(14)]
        public DateTime DataNascimento { get; set; }

        [Obrigatorio]
        public int IdUsuarioCadastro { get; set; }

        public List<ContaContatoRequest>? ContatoConta { get; set; }
    }
}
