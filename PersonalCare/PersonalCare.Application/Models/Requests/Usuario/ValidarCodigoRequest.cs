namespace PersonalCare.Application.Models.Requests.Usuario
{
    public class ValidarCodigoRequest
    {
        public string Email { get; set; }
        public string Codigo { get; set; }
        public string IdEmpresa { get; set; }
    }
}
