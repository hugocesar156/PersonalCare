namespace PersonalCare.Domain.Entities
{
    public class Treino
    {
        public Treino(int idTreino, string nome, string descricao, CategoriaTreino categoria)
        {
            IdTreino = idTreino;
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
        }

        public int IdTreino { get; private set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public CategoriaTreino Categoria { get; set; }
    }
}
