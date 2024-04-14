using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Empresarial
{
    public partial class EMPRESA_CONTATO
    {
        public int ID { get; set; }
        public string NOME { get; set; } = null!;
        public string NUMERO { get; set; } = null!;
        public string DDD { get; set; } = null!;
        public string DDI { get; set; } = null!;
        public int ID_EMPRESA { get; set; }

        public virtual EMPRESA ID_EMPRESANavigation { get; set; } = null!;
    }
}
