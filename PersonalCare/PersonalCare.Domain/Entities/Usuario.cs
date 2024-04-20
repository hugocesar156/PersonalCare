namespace PersonalCare.Domain.Entities
{
    public class Usuario
    {
        public Usuario(int _id, string _senha, string _salt, string _idEmpresa)
        {
            Id = _id;
            Nome = string.Empty;
            Email = string.Empty;
            Senha = _senha;
            Salt = _salt;
            IdEmpresa = _idEmpresa;
            Permissoes = new List<PermissaoUsuario>();

        }
        public Usuario(int _id, string _nome, string _email, bool _ativo, string _idEmpresa)
        {
            Id = _id;
            Nome = _nome;
            Email = _email;
            Senha = string.Empty;
            Salt = string.Empty;
            Ativo = _ativo;
            IdEmpresa = _idEmpresa;
            Permissoes = new List<PermissaoUsuario>();
        }


        public Usuario(string _nome, string _email, string _senha, string _salt, string _idEmpresa)
        {
            Nome = _nome;
            Email = _email;
            Senha = _senha;
            Salt = _salt;
            IdEmpresa = _idEmpresa;
            Permissoes = new List<PermissaoUsuario>();
        }

        public Usuario(int _id, string _nome, string _email, bool _ativo, DateTime _dataCadastro, DateTime _dataAtualizacao, DateTime? _dataUltimoAcesso)
        {
            Id = _id;
            Nome = _nome;
            Email = _email;
            Ativo = _ativo;
            Senha = string.Empty;
            Salt = string.Empty;
            IdEmpresa = string.Empty;
            DataCadastro = _dataCadastro;
            DataAtaualizacao = _dataAtualizacao;
            DataUltimoAcesso = _dataUltimoAcesso;
            Permissoes = new List<PermissaoUsuario>();
        }

        public Usuario(int _id, string _nome, string _email, string _senha, string _salt, bool _ativo, string _idEmpresa, DateTime _dataCadastro, DateTime _dataAtualizacao, DateTime? _dataUltimoAcesso, List<PermissaoUsuario> _permissoes)
        {
            Id = _id;
            Nome = _nome;  
            Email = _email; 
            Senha = _senha;
            Salt = _salt;
            Ativo = _ativo;
            IdEmpresa = _idEmpresa;
            DataCadastro = _dataCadastro;
            DataAtaualizacao = _dataAtualizacao;
            DataUltimoAcesso = _dataUltimoAcesso;
            Permissoes = _permissoes;
        }

        public int Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public string Senha { get; }
        public string Salt { get; }
        public bool Ativo { get; }
        public string IdEmpresa { get; }
        public DateTime DataCadastro { get; }
        public DateTime DataAtaualizacao { get; }
        public DateTime? DataUltimoAcesso { get; }
        public List<PermissaoUsuario> Permissoes { get; set; }
    }
}
