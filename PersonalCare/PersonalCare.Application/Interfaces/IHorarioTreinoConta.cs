using PersonalCare.Application.Models.Requests.HorarioTreino;
using PersonalCare.Application.Models.Responses.HorarioTreino;

namespace PersonalCare.Application.Interfaces
{
    public interface IHorarioTreinoConta
    {
        void Atualizar(AtualizarHorarioTreinoRequest request);
        HorarioTreinoContaResponse Buscar(int idConta, string idEmpresa);
        void Inserir(InserirHorarioTreinoRequest request);
        void Deletar(int idHorarioTreino);
        List<HorarioTreinoUsuarioResponse> ListarPorUsuario(int idUsuario, string idEmpresa);
    }
}
