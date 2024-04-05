namespace PersonalCare.Domain.Entities
{
    public class Conta
    {
        public Conta(int _id, string _nome, string _email, string _cpf, decimal? _altura, string? _biotipo, DateTime _dataNascimento, DateTime _dataCadastro, DateTime _dataAtualizacao, int _idUsuarioCadastro, List<ContatoConta> contatos)
        {
            Id = _id;
            Nome = _nome;
            Email = _email;
            Cpf = _cpf;
            Altura = _altura;
            Biotipo = _biotipo;
            DataNascimento = _dataNascimento;
            DataCadastro = _dataCadastro;
            DataAtualizacao = _dataAtualizacao;
            IdUsuarioCadastro = _idUsuarioCadastro;
            Contatos = contatos;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public decimal? Altura { get; private set; }
        public string? Biotipo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
        public int IdUsuarioCadastro { get; private set; }
        public List<ContatoConta> Contatos { get; private set; }
    }
}
