using PersonalCare.Application.Models.Requests.Usuario;
using PersonalCare.Application.Models.Responses.Usuario;

namespace PersonalCare.Application.Interfaces
{
    public interface IUsuario
    {
        AutenticarResponse Autenticar(AutenticarRequest request);
        void Cadastrar(CadastrarUsuarioRequest request);
    }
}
