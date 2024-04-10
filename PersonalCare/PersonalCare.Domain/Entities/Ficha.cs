namespace PersonalCare.Domain.Entities
{
    public class Ficha
    {
        public Ficha(int _id, DateTime _dataCriacao, DateTime _dataValidade, int _idConta, int _idUsuarioCadastro, List<ItemFicha> _itemFicha)
        {
            Id = _id;
            DataCriacao = _dataCriacao;
            DataValidade = _dataValidade;
            IdConta = _idConta;
            IdUsuarioCadastro = _idUsuarioCadastro;
            ItemFicha = _itemFicha;
        }

        public int Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public int IdConta { get; private set; }
        public int IdUsuarioCadastro { get; private set; }
        public List<ItemFicha> ItemFicha { get; private set; }
    }
}
