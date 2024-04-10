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

        public int Id { get; private set; }
        public string Grupo { get; private set; }
        public byte Series { get; private set; }
        public byte Repeticoes { get; private set; }
        public int IdFicha { get; private set; }
        public Treino Treino { get; private set; }
    }
}
