using PersonalCare.Application.Models.Responses.CategoriaTreino;

namespace PersonalCare.Application.Models.Responses.Treino
{
    public class TreinoResponse
    {
        public TreinoResponse(int _id, string _nome, string _descricao, Domain.Entities.CategoriaTreino _categoria)
        {
            Id = _id;
            Nome = _nome;
            Descricao = _descricao;
            Categoria = new CategoriaTreinoResponse(_categoria.Id, _categoria.Nome);
        }

        public int Id { get; }
        public string Nome { get; }
        public string Descricao { get; }
        public CategoriaTreinoResponse Categoria { get; }
    }
}
