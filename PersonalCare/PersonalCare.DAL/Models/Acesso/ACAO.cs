using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Acesso
{
    public partial class ACAO
    {
        public ACAO()
        {
            PERMISSAOs = new HashSet<PERMISSAO>();
        }

        public int ID { get; set; }
        public string NOME { get; set; } = null!;

        public virtual ICollection<PERMISSAO> PERMISSAOs { get; set; }
    }
}
