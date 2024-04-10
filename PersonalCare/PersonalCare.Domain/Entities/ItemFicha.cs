namespace PersonalCare.Domain.Entities
{
    public class ItemFicha
    {
        public ItemFicha(int _id, string _grupo, byte _series, byte _repeticoes, int _idFicha, Treino _treino)
        {
            Id = _id;
            Grupo = _grupo;
            Series = _series;
            Repeticoes = _repeticoes;
            IdFicha = _idFicha;
            Treino = _treino;
        }

        public int Id { get; }
        public string Grupo { get; }
        public byte Series { get; }
        public byte Repeticoes { get; }
        public int IdFicha { get; }
        public Treino Treino { get; }
    }
}
