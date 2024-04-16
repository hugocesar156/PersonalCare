namespace PersonalCare.Application.Models.Requests.Usuario
{
    public class RemoverPermissaoRequest
    {
        public RemoverPermissaoRequest()
        {
            Permissoes = new List<int>();
        }

        public int IdUsuario { get; set; }
        public List<int> Permissoes { get; set; }
    }
}
