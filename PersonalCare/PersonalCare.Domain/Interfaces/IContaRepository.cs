using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IContaRepository
    {
        Conta? Atualizar(Conta request);
        bool AtualizarContato(ContatoConta request);
        Conta? Buscar(int idConta);
        Conta? Buscar(string cpf);
        bool Deletar(int idConta);
        int Inserir(Conta request);
        bool InserirContato(ContatoConta request);
        void InserirContato(List<ContatoConta> request);
        List<Conta>? Listar();
    }
}
