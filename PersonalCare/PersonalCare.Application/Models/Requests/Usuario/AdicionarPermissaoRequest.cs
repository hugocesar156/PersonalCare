namespace PersonalCare.Application.Models.Requests.Usuario
{
    public class AdicionarPermissaoRequest
    {
        public AdicionarPermissaoRequest()
        {
            Permissoes = new List<PermissaoRequest>();
        }

        public int IdUsuario { get; set; }
        public List<PermissaoRequest> Permissoes { get; set; }
    }
}
