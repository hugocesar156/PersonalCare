namespace PersonalCare.Application.Models.Responses.Usuario
{
    public class UsuarioResponse : Usuario
    {
        public UsuarioResponse(int _id, string _nome, string _email, bool _ativo, DateTime _dataCadastro, DateTime _dataAtualizacao, DateTime? _dataUltimoAcesso, List<Domain.Entities.PermissaoUsuario> _permissoes)
        {
            Id = _id;
            Nome = _nome;
            Email = _email;
            Ativo = _ativo;
            DataCadastro = _dataCadastro;
            DataAtualizacao = _dataAtualizacao;
            DataUltimoAcesso = _dataUltimoAcesso;
            Permissoes = _permissoes.Select(up => new PermissaoResponse(up.Id, up.Permissao.Nome, up.Permissao.Descricao)).ToList();
        }

        public List<PermissaoResponse> Permissoes { get; }
    }
}
