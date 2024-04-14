namespace PersonalCare.Application.Models.Responses.CategoriaTreino
{
    public class CategoriaTreinoResponse
    {
        public CategoriaTreinoResponse(int _id, string _nome)
        {
            Id = _id;
            Nome = _nome;
        }

        public int Id { get; }
        public string Nome { get; }
    }
}
