using PersonalCare.Application.Models.Requests.Usuario;
using PersonalCare.Application.Models.Responses.Usuario;

namespace PersonalCare.Application.Interfaces
{
    public interface IUsuario
    {
        void AdicionarPermissoes(AdicionarPermissaoRequest request, string idEmpresa);
        AutenticarResponse Autenticar(AutenticarRequest request);
        UsuarioResponse Buscar(int idUsuario, string idEmpresa);
        void Cadastrar(CadastrarUsuarioRequest request, string idEmpresa);
        void RemoverPermissoes(RemoverPermissaoRequest request, string idEmpresa);
    }
}
