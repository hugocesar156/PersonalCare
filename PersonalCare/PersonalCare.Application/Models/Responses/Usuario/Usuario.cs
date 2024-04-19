namespace PersonalCare.Application.Models.Responses.Usuario
{
    public abstract class Usuario
    {
        public Usuario()
        {
            Nome = string.Empty;
            Email = string.Empty;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }
    }
}
