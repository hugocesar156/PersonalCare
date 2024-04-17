using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Acesso
{
    public partial class PERMISSAO
    {
        public PERMISSAO()
        {
            USUARIO_PERMISSAOs = new HashSet<USUARIO_PERMISSAO>();
        }

        public int ID { get; set; }
        public string NOME { get; set; } = null!;
        public string? DESCRICAO { get; set; }
        public int ID_ENTIDADE { get; set; }
        public int ID_ACAO { get; set; }

        public virtual ACAO ID_ACAONavigation { get; set; } = null!;
        public virtual ENTIDADE ID_ENTIDADENavigation { get; set; } = null!;
        public virtual ICollection<USUARIO_PERMISSAO> USUARIO_PERMISSAOs { get; set; }
    }
}
