using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Empresarial
{
    public partial class EMPRESA_EMAIL
    {
        public int ID { get; set; }
        public string EMAIL { get; set; } = null!;
        public string SENHA { get; set; } = null!;
        public string SMTP { get; set; } = null!;
        public int PORTA { get; set; }
        public bool SSL { get; set; }
        public int ID_EMPRESA { get; set; }

        public virtual EMPRESA ID_EMPRESANavigation { get; set; } = null!;
    }
}
