namespace PersonalCare.Domain.Entities
{
    public class PermissaoUsuario
    {
        public PermissaoUsuario(int _iUsuario, Entidade _entidade, Acao _acao)
        {
            IdUsuario = _iUsuario;
            Entidade = _entidade;
            Acao = _acao;
        }

        public PermissaoUsuario(int _id, int _iUsuario, Entidade _entidade, Acao _acao)
        {
            Id = _id;
            IdUsuario = _iUsuario;
            Entidade = _entidade;
            Acao = _acao;
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public Entidade Entidade { get; set; }
        public Acao Acao { get; set; }
    }
}
