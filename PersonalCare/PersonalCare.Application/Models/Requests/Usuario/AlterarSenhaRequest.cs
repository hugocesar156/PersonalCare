using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Usuario
{
    public class AlterarSenhaRequest
    {
        [Obrigatorio]
        public string Senha { get; set; }
    }
}
