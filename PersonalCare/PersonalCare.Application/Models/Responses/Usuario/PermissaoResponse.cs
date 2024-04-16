using PersonalCare.Domain.Entities;

namespace PersonalCare.Application.Models.Responses.Usuario
{
    public class PermissaoResponse
    {
        public PermissaoResponse(int _id, Entidade _entiade, Acao _acao)
        {
            Id = _id;
            Entidade = new EntidadeResponse(_entiade.Id, _entiade.Nome);
            Acao = new AcaoResponse(_acao.Id, _acao.Nome);
        }

        public int Id { get; }
        public EntidadeResponse Entidade { get; }
        public AcaoResponse Acao { get; }
    }
}
