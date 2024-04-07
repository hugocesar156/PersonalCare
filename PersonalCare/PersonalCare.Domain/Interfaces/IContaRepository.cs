using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IContaRepository
    {
        bool Atualizar(Conta request);
        bool AtualizarContato(ContatoConta request);
        Conta? Buscar(int idConta);
        (string, string) BuscarDadosExistentes(string cpf, string email, int idConta = 0);
        bool Deletar(int idConta);
        bool DeletarContato(int idContato);
        int Inserir(Conta request);
        bool InserirContato(ContatoConta request);
        bool InserirContato(List<ContatoConta> request);
        List<Conta>? Listar();
    }
}
