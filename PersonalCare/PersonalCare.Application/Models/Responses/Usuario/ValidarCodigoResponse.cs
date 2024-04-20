namespace PersonalCare.Application.Models.Responses.Usuario
{
    public class ValidarCodigoResponse
    {
        public ValidarCodigoResponse(string _tokenAcesso, DateTime dataExpiracao)
        {
            TokenAcesso = _tokenAcesso;
            DataExpiracao = dataExpiracao;
        }

        public string TokenAcesso { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}
