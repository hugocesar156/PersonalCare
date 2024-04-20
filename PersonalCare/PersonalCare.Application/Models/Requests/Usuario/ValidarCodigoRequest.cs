using PersonalCare.Application.Validations;

namespace PersonalCare.Application.Models.Requests.Usuario
{
    public class ValidarCodigoRequest
    {
        [Obrigatorio, Email]
        public string Email { get; set; }

        [Obrigatorio]
        public string Codigo { get; set; }

        [Obrigatorio]
        public string IdEmpresa { get; set; }
    }
}
