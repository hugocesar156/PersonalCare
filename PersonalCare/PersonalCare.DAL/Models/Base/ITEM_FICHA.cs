using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Base
{
    public partial class ITEM_FICHA
    {
        public int ID { get; set; }
        public int SERIES { get; set; }
        public int REPETICOES { get; set; }
        public int ID_FICHA { get; set; }
        public int ID_TREINO { get; set; }
        public string GRUPO { get; set; } = null!;

        public virtual FICHA ID_FICHANavigation { get; set; } = null!;
        public virtual TREINO ID_TREINONavigation { get; set; } = null!;
    }
}
