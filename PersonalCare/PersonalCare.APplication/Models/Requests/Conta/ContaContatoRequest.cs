namespace PersonalCare.Application.Models.Requests.Conta
{
    public class ContatoContaRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Ddd { get; set; }
        public string Ddi { get; set; }
        public int IdConta { get; set; }
    }
}
