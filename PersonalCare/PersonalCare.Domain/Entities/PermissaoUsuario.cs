namespace PersonalCare.Domain.Entities
{
    public class PermissaoUsuario
    {
        public PermissaoUsuario(int _iUsuario, Permissao _permissao)
        {
            IdUsuario = _iUsuario;
            Permissao = _permissao;
        }

        public PermissaoUsuario(int _id, int _iUsuario, Permissao _permissao)
        {
            Id = _id;
            IdUsuario = _iUsuario;
            Permissao = _permissao;
        }

        public int Id { get; }
        public int IdUsuario { get; }
        public Permissao Permissao { get; }
    }
}
