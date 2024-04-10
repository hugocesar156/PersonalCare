namespace PersonalCare.Domain.Entities
{
    public class ItemFicha
    {
        public ItemFicha(int _id, byte _series, byte _repeticoes, int _idFicha, int _idTreino)
        {
            Id = _id;
            Series = _series;
            Repeticoes = _repeticoes;
            IdFicha = _idFicha;
            IdTreino  = _idTreino;
        }

        public int Id { get; private set; }
        public byte Series { get; private set; }
        public byte Repeticoes { get; private set; }
        public int IdFicha { get; private set; }
        public int IdTreino { get; private set; }
    }
}
