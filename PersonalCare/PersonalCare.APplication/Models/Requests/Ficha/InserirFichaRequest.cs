namespace PersonalCare.Application.Models.Requests.Ficha
{
    public class InserirFichaRequest
    {
        public InserirFichaRequest()
        {
            ItemFicha = new List<ItemFichaRequest>();
        }

        public DateTime DataValidade { get; set; }
        public int IdConta { get; set; }
        public int IdUsuarioCadastro { get; set; }
        public List<ItemFichaRequest> ItemFicha { get; set; }
    }
}
