using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Data
{
    public partial class USUARIO
    {
        public USUARIO()
        {
            CONTa = new HashSet<CONTum>();
            FICHAs = new HashSet<FICHA>();
        }

        public int ID { get; set; }
        public string NOME { get; set; } = null!;
        public string EMAIL { get; set; } = null!;
        public string SENHA { get; set; } = null!;
        public DateTime DATA_CADASTRO { get; set; }
        public DateTime DATA_ATUALIZACAO { get; set; }
        public DateTime? DATA_ULTIMO_ACESSO { get; set; }
        public string SALT { get; set; } = null!;
        public bool ATIVO { get; set; }

        public virtual ICollection<CONTum> CONTa { get; set; }
        public virtual ICollection<FICHA> FICHAs { get; set; }
    }
}
