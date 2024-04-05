using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Data
{
    public partial class FICHA
    {
        public FICHA()
        {
            ITEM_FICHAs = new HashSet<ITEM_FICHA>();
        }

        public int ID { get; set; }
        public DateTime DATA_CRIACAO { get; set; }
        public DateTime DATA_VALIDADE { get; set; }
        public int ID_CONTA { get; set; }
        public int ID_USUARIO_CADASTRO { get; set; }

        public virtual CONTum ID_CONTANavigation { get; set; } = null!;
        public virtual USUARIO ID_USUARIO_CADASTRONavigation { get; set; } = null!;
        public virtual ICollection<ITEM_FICHA> ITEM_FICHAs { get; set; }
    }
}
