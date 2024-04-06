using PersonalCare.Application.Validation;

namespace PersonalCare.Application.Models.Requests.Conta
{
    public class ContaContatoRequest
    {
        [Obrigatorio, TamanhoMaximo(50)]
        public string Nome { get; set; }

        [Obrigatorio, TamanhoMaximo(20)]
        public string Numero { get; set; }

        [Obrigatorio, TamanhoMaximo(3)]
        public string Ddd { get; set; }

        [Obrigatorio, TamanhoMaximo(3)]
        public string Ddi { get; set; }
    }
}
