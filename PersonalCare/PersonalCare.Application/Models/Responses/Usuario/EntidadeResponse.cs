namespace PersonalCare.Application.Models.Responses.Usuario
{
    public class EntidadeResponse
    {
        public EntidadeResponse(byte _id, string nome)
        {
            Id = _id;
            Nome = nome;
        }

        public byte Id { get; set; }
        public string Nome { get; set; }
    }
}
