namespace PersonalCare.Domain.Entities
{
    public class Acao
    {
        public Acao()
        {
            Nome = string.Empty;
        }

        public Acao(byte _id)
        {
            Id = _id;
            Nome = string.Empty;
        }

        public Acao(byte _id, string _nome)
        {
            Id = _id;
            Nome = _nome;
        }

        public byte Id { get; set; }
        public string Nome { get; set; }
    }
}
