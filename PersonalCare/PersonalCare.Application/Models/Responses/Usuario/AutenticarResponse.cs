namespace PersonalCare.Application.Models.Responses.Usuario
{
    public class AutenticarResponse
    {
        public AutenticarResponse(string _nome, string _tokenAcesso)
        {
            Nome = _nome;
            TokenAcesso = _tokenAcesso;
        }

        public string Nome { get; }
        public string TokenAcesso { get; }
    }
}
