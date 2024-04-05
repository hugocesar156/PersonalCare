namespace PersonalCare.Domain.Entities
{
    public class ContatoConta
    {
        public ContatoConta(int _id, string _nome, string _numero, string _ddd, string _ddi, int _idConta)
        {
            Id = _id;
            Nome = _nome;
            Numero = _numero;
            Ddd = _ddd;
            Ddi = _ddi;
            IdConta = _idConta;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; } 
        public string Numero { get; private set; } 
        public string Ddd { get; private set; } 
        public string Ddi { get; private set; }
        public int IdConta { get; private set; }
    }
}
