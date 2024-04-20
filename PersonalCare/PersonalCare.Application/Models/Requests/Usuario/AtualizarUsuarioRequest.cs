using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Usuario
{
    public class AtualizarUsuarioRequest
    {
        [Obrigatorio]
        public int Id { get; set; }

        [Obrigatorio, TamanhoMaximo(100)]
        public string Nome { get; set; }

        [Obrigatorio, TamanhoMaximo(50)]
        public string Email { get; set; }

        [Obrigatorio]
        public bool Ativo { get; set; }
    }
}
