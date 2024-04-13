using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Usuario
{
    public class CadastrarUsuarioRequest
    {
        [Obrigatorio, TamanhoMaximo(50)]
        public string Nome { get; set; }

        [Obrigatorio, Email, TamanhoMaximo(50)]
        public string Email { get; set; }

        [Obrigatorio]
        public string Senha { get; set; }
    }
}
