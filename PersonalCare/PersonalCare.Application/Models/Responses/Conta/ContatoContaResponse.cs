namespace PersonalCare.Application.Models.Responses.Conta
{
    public class ContatoContaResponse
    {
        public ContatoContaResponse(int _id, string nome, string _numero, string _ddd, string _ddi, int _idConta)
        {
            Id = _id;
            Nome = nome;
            Numero = _numero;
            Ddd = _ddd;
            Ddi = _ddi;
            IdConta = _idConta;
        }

        public int Id { get; }
        public string Nome { get; }
        public string Numero { get; }
        public string Ddd { get; }
        public string Ddi { get; }
        public int IdConta { get; }
    }
}
