using PersonalCare.Application.Models.Requests.Usuario;

namespace PersonalCare.Application.Interfaces
{
    public interface IUsuario
    {
        void Cadastrar(CadastrarUsuarioRequest request);
    }
}
