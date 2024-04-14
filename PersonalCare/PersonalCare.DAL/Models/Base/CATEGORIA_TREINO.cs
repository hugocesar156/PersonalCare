using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Base
{
    public partial class CATEGORIA_TREINO
    {
        public CATEGORIA_TREINO()
        {
            TREINOs = new HashSet<TREINO>();
        }

        public int ID { get; set; }
        public string NOME { get; set; } = null!;

        public virtual ICollection<TREINO> TREINOs { get; set; }
    }
}
