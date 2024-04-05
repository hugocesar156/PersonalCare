using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Data
{
    public partial class TREINO
    {
        public TREINO()
        {
            ITEM_FICHAs = new HashSet<ITEM_FICHA>();
        }

        public int ID { get; set; }
        public string NOME { get; set; } = null!;
        public string DESCRICAO { get; set; } = null!;
        public int ID_CATEGORIA_TREINO { get; set; }

        public virtual CATEGORIA_TREINO ID_CATEGORIA_TREINONavigation { get; set; } = null!;
        public virtual ICollection<ITEM_FICHA> ITEM_FICHAs { get; set; }
    }
}
