namespace PersonalCare.Domain.Entities
{
    public class RedefinicaoSenhaUsuario
    {
        public RedefinicaoSenhaUsuario(int _idUsuario, string _codigo)
        {
            IdUsuario = _idUsuario;
            Codigo = _codigo;
        }

        public int Id { get; }
        public int IdUsuario { get; }
        public string Codigo { get; }
        public DateTime DataPedido { get; }
    }
}
