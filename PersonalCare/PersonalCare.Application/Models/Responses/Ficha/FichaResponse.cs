namespace PersonalCare.Application.Models.Responses.Ficha
{
    public class FichaResponse
    {
        public FichaResponse(int _id, DateTime _dataCriacao, DateTime _dataValidade, int _idConta, int _idUsuarioCaastro, List<Domain.Entities.ItemFicha> _itemFicha)
        {
            Id = _id;
            DataCriacao = _dataCriacao;
            DataValidade = _dataValidade;
            IdConta = _idConta;
            IdUsuarioCadastro = _idUsuarioCaastro;
            ItemFicha = _itemFicha.Select(i => new ItemFichaResponse(i.Id, i.Grupo, i.Repeticoes, i.Series, i.Treino)).ToList();
        }

        public int Id { get; }
        public DateTime DataCriacao { get; }
        public DateTime DataValidade { get; }
        public int IdConta { get; }
        public int IdUsuarioCadastro { get; }
        public List<ItemFichaResponse> ItemFicha { get; }
    }
}
