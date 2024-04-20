namespace PersonalCare.Domain.Entities
{
    public class EmailEmpresa
    {
        public EmailEmpresa(int _id, string _email, string _senha, string _smtp, int _porta, bool _ssl, int idEmpresa)
        {
            Id = _id;
            Email = _email;
            Senha = _senha;
            Smtp = _smtp;
            Porta = _porta;
            Ssl = _ssl;
            IdEmpresa = idEmpresa;
        }

        public int Id { get; }
        public string Email { get; }
        public string Senha { get; }
        public string Smtp { get; }
        public int Porta { get; }
        public bool Ssl { get; }
        public int IdEmpresa { get; }
    }
}
