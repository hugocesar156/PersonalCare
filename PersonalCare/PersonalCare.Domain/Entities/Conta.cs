namespace PersonalCare.Domain.Entities
{
    public class Conta
    {
        public Conta()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Cpf = string.Empty;
            Senha = string.Empty;
            Salt = string.Empty;
            Contatos = new List<ContatoConta>();
        }

        public Conta(int _id, string _nome, List<ContatoConta> _contatos)
        {
            Id = _id;
            Nome = _nome;
            Email = string.Empty;
            Cpf = string.Empty;
            Senha = string.Empty;
            Salt = string.Empty;
            Contatos = _contatos;
        }

        public Conta(string _nome, string _email, string _cpf, decimal? _altura, string? _biotipo, DateTime _dataNascimento, string _senha, string _salt, int _idUsuarioCadastro)
        {
            Nome = _nome;
            Email = _email;
            Cpf = _cpf;
            Altura = _altura;
            Biotipo = _biotipo;
            DataNascimento = _dataNascimento;
            Senha = _senha;
            Salt = _salt;
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
            Senha = string.Empty;
            Salt = string.Empty;
            Contatos = new List<ContatoConta>();
        }

        public Conta(int _id, string _nome, string _email, string _cpf, decimal? _altura, string? _biotipo, DateTime _dataNascimento, string _senha, string _salt)
        {
            Id = _id;
            Nome = _nome;
            Email = _email;
            Cpf = _cpf;
            Altura = _altura;
            Biotipo = _biotipo;
            DataNascimento = _dataNascimento;
            Senha = _senha;
            Salt = _salt;
            Contatos = new List<ContatoConta>();
        }

        public Conta(int _id, string _nome, string _email, string _cpf, decimal? _altura, string? _biotipo, DateTime _dataNascimento, DateTime _dataCadastro, DateTime _dataAtualizacao, int _idUsuarioCadastro, List<ContatoConta> _contatos)
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
            Senha = string.Empty;
            Salt = string.Empty;
            IdUsuarioCadastro = _idUsuarioCadastro;
            Contatos = _contatos;
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
        public string Senha { get; }
        public string Salt { get; }
        public int IdUsuarioCadastro { get; }
        public List<ContatoConta> Contatos { get; }
    }
}
