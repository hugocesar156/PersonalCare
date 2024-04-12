namespace PersonalCare.Domain.Entities
{
    public class Conta
    {
        public Conta(string _nome, string _email, string _cpf, decimal? _altura, string? _biotipo, DateTime _dataNascimento, int _idUsuarioCadastro)
        {
            Nome = _nome;
            Email = _email;
            Cpf = _cpf;
            Altura = _altura;
            Biotipo = _biotipo;
            DataNascimento = _dataNascimento;
            IdUsuarioCadastro = _idUsuarioCadastro;
            Contatos = new List<ContatoConta>();
        }

        public Conta(int _id, string _nome, string _email, string _cpf, decimal? _altura, string? _biotipo, DateTime _dataNascimento)
        {
            Id = _id;
            Nome = _nome;
            Email = _email;
            Cpf = _cpf;
            Altura = _altura;
            Biotipo = _biotipo;
            DataNascimento = _dataNascimento;
            Contatos = new List<ContatoConta>();
        }

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

        public int Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public string Cpf { get; }
        public decimal? Altura { get; }
        public string? Biotipo { get; }
        public DateTime DataNascimento { get; }
        public DateTime DataCadastro { get; }
        public DateTime DataAtualizacao { get; }
        public int IdUsuarioCadastro { get; }
        public List<ContatoConta> Contatos { get; }
    }
}
