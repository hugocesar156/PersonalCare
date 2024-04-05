using PersonalCare.Domain.Entities;

namespace PersonalCare.Domain.Interfaces
{
    public interface IContaRepository
    {
        Conta Buscar(int idConta);
        Conta Buscar(string cpf);
        int Inserir(Conta request);
        void InserirContato(List<ContatoConta> request);
        List<Conta> Listar();
    }
}
