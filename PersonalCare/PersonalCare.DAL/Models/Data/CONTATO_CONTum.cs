using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Data
{
    public partial class CONTATO_CONTum
    {
        public int ID { get; set; }
        public string NOME { get; set; } = null!;
        public string NUMERO { get; set; } = null!;
        public string DDD { get; set; } = null!;
        public string DDI { get; set; } = null!;
        public int ID_CONTA { get; set; }

        public virtual CONTum ID_CONTANavigation { get; set; } = null!;
    }
}
