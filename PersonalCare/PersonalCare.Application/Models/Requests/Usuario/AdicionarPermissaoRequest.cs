namespace PersonalCare.Application.Models.Requests.Usuario
{
    public class AdicionarPermissaoRequest
    {
        public AdicionarPermissaoRequest()
        {
            Permissoes = new List<Permissao>();
        }

        public int IdUsuario { get; set; }
        public List<Permissao> Permissoes { get; set; }
    }
}
