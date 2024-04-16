namespace PersonalCare.Application.Models.Responses.Usuario
{
    public class AcaoResponse
    {
        public AcaoResponse(byte _id, string _nome)
        {
            Id = _id;
            Nome = _nome;
        }

        public byte Id { get; set; }
        public string Nome { get; set; }
    }
}
