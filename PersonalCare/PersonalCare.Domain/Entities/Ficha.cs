namespace PersonalCare.Domain.Entities
{
    public class Ficha
    {
        public Ficha(int _id, DateTime _dataValidade)
        {
            Id = _id;
            DataValidade = _dataValidade;
            ItemFicha = new List<ItemFicha>();
        }

        public Ficha(DateTime _dataValidade, int _idConta, int _idUsuarioCadastro, List<ItemFicha> _itemFicha)
        {
            DataValidade = _dataValidade;
            IdConta = _idConta;
            IdUsuarioCadastro = _idUsuarioCadastro;
            ItemFicha = _itemFicha;
        }

        public Ficha(int _id, DateTime _dataCriacao, DateTime _dataValidade, int _idConta, int _idUsuarioCadastro, List<ItemFicha> _itemFicha)
        {
            Id = _id;
            DataCriacao = _dataCriacao;
            DataValidade = _dataValidade;
            IdConta = _idConta;
            IdUsuarioCadastro = _idUsuarioCadastro;
            ItemFicha = _itemFicha;
        }

        public int Id { get; }
        public DateTime DataCriacao { get; }
        public DateTime DataValidade { get; }
        public int IdConta { get; }
        public int IdUsuarioCadastro { get; }
        public List<ItemFicha> ItemFicha { get; }
    }
}
