namespace PersonalCare.Application.Models.Responses.Usuario
{
    public class ListarUsuarioResponse : Usuario
    {
        public ListarUsuarioResponse(int _id, string _nome, string _email, bool _ativo, DateTime _dataCadastro, DateTime _dataAtualizacao, DateTime? _dataUltimoAcesso)
        {
            Id = _id;
            Nome = _nome;
            Email = _email;
            Ativo = _ativo;
            DataCadastro = _dataCadastro;
            DataAtualizacao = _dataAtualizacao;
            DataUltimoAcesso = _dataUltimoAcesso;
        }
    }
}
