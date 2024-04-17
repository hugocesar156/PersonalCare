namespace PersonalCare.Domain.Entities
{
    public class Permissao
    {
        public Permissao(int _id)
        {
            Id = _id;
            Nome = string.Empty;
            Entidade = new Entidade();
            Acao = new Acao();
        }

        public Permissao(int _id, string nome, string? descricao, Entidade _entidade, Acao _acao)
        {
            Id = _id;
            Nome = nome;
            Descricao = descricao;
            Entidade = _entidade;
            Acao = _acao;
        }

        public int Id { get; }
        public string Nome { get; }
        public string? Descricao { get; }
        public Entidade Entidade { get; }
        public Acao Acao { get; }
    }
}
