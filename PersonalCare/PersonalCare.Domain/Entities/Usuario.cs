namespace PersonalCare.Domain.Entities
{
    public class Usuario
    {
        public Usuario(string _nome, string _email, string _senha, string _salt)
        {
            Nome = _nome;
            Email = _email;
            Senha = _senha;
            Salt = _salt;
        }

        public Usuario(int _id, string _nome, string _email, string _senha, string _salt, bool _ativo, DateTime _dataCadastro, DateTime _dataAtualizacao, DateTime _dataUltimoAcesso)
        {
            Id = _id;
            Nome = _nome;  
            Email = _email; 
            Senha = _senha;
            Salt = _salt;
            Ativo = _ativo;
            DataCadastro = _dataCadastro;
            DataAtaualizacao = _dataAtualizacao;
            DataUltimoAcesso = _dataUltimoAcesso;
        }

        public int Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public string Senha { get; }
        public string Salt { get; }
        public bool Ativo { get; }
        public DateTime DataCadastro { get; }
        public DateTime DataAtaualizacao { get; }
        public DateTime DataUltimoAcesso { get; }
    }
}
