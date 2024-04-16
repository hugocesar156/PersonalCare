namespace PersonalCare.Application.Models.Responses.Usuario
{
    public class UsuarioResponse
    {
        public UsuarioResponse(int _id, string _nome, string _email, bool ativo, List<Domain.Entities.PermissaoUsuario> _permissoes)
        {
            Id = _id;
            Nome = _nome;
            Email = _email;
            Ativo = ativo;
            Permissoes = _permissoes.Select(up => new PermissaoResponse(up.Id, up.Entidade, up.Acao)).ToList();
        }

        public int Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public bool Ativo { get; }
        public List<PermissaoResponse> Permissoes { get; }
    }
}
