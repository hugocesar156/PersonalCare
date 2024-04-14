using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Acesso
{
    public partial class ACAO
    {
        public ACAO()
        {
            USUARIO_PERMISSAOs = new HashSet<USUARIO_PERMISSAO>();
        }

        public int ID { get; set; }
        public string NOME { get; set; } = null!;

        public virtual ICollection<USUARIO_PERMISSAO> USUARIO_PERMISSAOs { get; set; }
    }
}
