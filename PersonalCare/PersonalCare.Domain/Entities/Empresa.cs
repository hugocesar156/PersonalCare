namespace PersonalCare.Domain.Entities
{
    public class Empresa
    {
        public Empresa(int _id, string _nomeFantasia, EmailEmpresa? _email)
        {
            Id = _id;
            NomeFantasia = _nomeFantasia;
            Email = _email;
        }

        public int Id { get; }
        public string NomeFantasia { get; }
        public EmailEmpresa? Email { get; set; }
    }
}
