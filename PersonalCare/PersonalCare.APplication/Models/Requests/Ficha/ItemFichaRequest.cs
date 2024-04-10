namespace PersonalCare.Application.Models.Requests.Ficha
{
    public class ItemFichaRequest
    {
        public byte Series { get; set; }
        public byte Repeticoes { get; set; }
        public int IdTreino { get; set; }
    }
}
