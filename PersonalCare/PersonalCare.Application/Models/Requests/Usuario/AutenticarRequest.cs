namespace PersonalCare.Application.Models.Requests.Usuario
{
    public class AutenticarRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string IdEmpresa { get; set; }
    }
}
