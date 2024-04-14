using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Acesso
{
    public partial class USUARIO_PERMISSAO
    {
        public int ID { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_ENTIDADE { get; set; }
        public int ID_ACAO { get; set; }

        public virtual ACAO ID_ACAONavigation { get; set; } = null!;
        public virtual ENTIDADE ID_ENTIDADENavigation { get; set; } = null!;
        public virtual USUARIO ID_USUARIONavigation { get; set; } = null!;
    }
}
