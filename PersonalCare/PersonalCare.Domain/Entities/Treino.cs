namespace PersonalCare.Domain.Entities
{
    public class Treino
    {
        public Treino(int _id, string _nome, string _descricao, CategoriaTreino _categoria)
        {
            Id = _id;
            Nome = _nome;
            Descricao = _descricao;
            Categoria = _categoria;
        }

        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public CategoriaTreino Categoria { get; set; }
    }
}
