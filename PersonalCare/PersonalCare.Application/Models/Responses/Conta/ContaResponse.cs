namespace PersonalCare.Application.Models.Responses.Conta
{
    public class ContaResponse
    {
        public ContaResponse(int _id, string _nome, string _email, string _cpf, decimal? _altuta, string? _biotipo, DateTime _dataNascimento, List<Domain.Entities.ContatoConta> _contatoConta)
        {
            Id = _id;
            Nome = _nome;
            Email = _email;
            Cpf = _cpf;
            Altura = _altuta;
            Biotipo = _biotipo;
            DataNascimento = _dataNascimento;
            ContatoConta = _contatoConta.Select(x => new ContatoConta(
                x.Id, x.Nome, x.Numero, x.Ddd, x.Ddi, x.IdConta)).ToList();
        }

        public int Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public string Cpf { get; }
        public decimal? Altura { get; }
        public string? Biotipo { get; }
        public DateTime DataNascimento { get; }
        public List<ContatoConta> ContatoConta { get; }
    }
}
