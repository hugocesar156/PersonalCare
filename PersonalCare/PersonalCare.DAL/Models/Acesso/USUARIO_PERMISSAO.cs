using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Acesso
{
    public partial class USUARIO_PERMISSAO
    {
        public int ID { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_PERMISSAO { get; set; }

        public virtual PERMISSAO ID_PERMISSAONavigation { get; set; } = null!;
        public virtual USUARIO ID_USUARIONavigation { get; set; } = null!;
    }
}
