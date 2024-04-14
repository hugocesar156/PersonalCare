using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Acesso
{
    public partial class USUARIO
    {
        public USUARIO()
        {
            USUARIO_PERMISSAOs = new HashSet<USUARIO_PERMISSAO>();
        }

        public int ID { get; set; }
        public string NOME { get; set; } = null!;
        public string EMAIL { get; set; } = null!;
        public string SENHA { get; set; } = null!;
        public string SALT { get; set; } = null!;
        public bool ATIVO { get; set; }
        public DateTime DATA_CADASTRO { get; set; }
        public DateTime DATA_ATUALIZACAO { get; set; }
        public DateTime? DATA_ULTIMO_ACESSO { get; set; }

        public virtual ICollection<USUARIO_PERMISSAO> USUARIO_PERMISSAOs { get; set; }
    }
}
