using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Usuario
{
    public class RemoverPermissaoRequest
    {
        public RemoverPermissaoRequest()
        {
            Permissoes = new List<int>();
        }

        [Obrigatorio]
        public int IdUsuario { get; set; }

        [Obrigatorio]
        public List<int> Permissoes { get; set; }
    }
}
