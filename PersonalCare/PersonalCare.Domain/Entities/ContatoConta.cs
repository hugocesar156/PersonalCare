namespace PersonalCare.Domain.Entities
{
    public class ContatoConta
    {
        public ContatoConta(string _nome, string _numero, string _ddd, string _ddi, int _idConta)
        {
            Nome = _nome;
            Numero = _numero;
            Ddd = _ddd;
            Ddi = _ddi;
            IdConta = _idConta;
        }

        public ContatoConta(int _id, string _nome, string _numero, string _ddd, string _ddi)
        {
            Id = _id;
            Nome = _nome;
            Numero = _numero;
            Ddd = _ddd;
            Ddi = _ddi;
        }

        public ContatoConta(int _id, string _nome, string _numero, string _ddd, string _ddi, int _idConta)
        {
            Id = _id;
            Nome = _nome;
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
