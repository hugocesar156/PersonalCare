namespace PersonalCare.Application.Models.Responses.Usuario
{
    public class AutenticarResponse
    {
        public AutenticarResponse(string _nomeUsuario, string _tokenAcesso)
        {
            NomeUsuario = _nomeUsuario;
            TokenAcesso = _tokenAcesso;
        }

        public string NomeUsuario { get; }
        public string TokenAcesso { get; }
    }
}
