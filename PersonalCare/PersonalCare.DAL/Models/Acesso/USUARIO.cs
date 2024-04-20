using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Acesso
{
    public partial class USUARIO
    {
        public USUARIO()
        {
            USUARIO_PERMISSAOs = new HashSet<USUARIO_PERMISSAO>();
            USUARIO_REDEFINICAO_SENHAs = new HashSet<USUARIO_REDEFINICAO_SENHA>();
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
        public string ID_EMPRESA { get; set; } = null!;

        public virtual ICollection<USUARIO_PERMISSAO> USUARIO_PERMISSAOs { get; set; }
        public virtual ICollection<USUARIO_REDEFINICAO_SENHA> USUARIO_REDEFINICAO_SENHAs { get; set; }
    }
}
