using PersonalCare.Application.Models.Responses.Treino;

namespace PersonalCare.Application.Models.Responses.Ficha
{
    public class ItemFichaResponse
    {
        public ItemFichaResponse(int _id, string _grupo, byte _series, byte _repeticoes, Domain.Entities.Treino _treino)
        {
            Id = _id;
            Grupo = _grupo;
            Series = _series;
            Repeticoes = _repeticoes;
            Treino = new TreinoResponse(_treino.Id, _treino.Nome, _treino.Descricao, _treino.Categoria);
        }

        public int Id { get; }
        public string Grupo { get; }
        public byte Series { get; }
        public byte Repeticoes { get; }
        public TreinoResponse Treino { get; }
    }
}
