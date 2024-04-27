using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Base
{
    public partial class CONTum
    {
        public CONTum()
        {
            CONTATO_CONTa = new HashSet<CONTATO_CONTum>();
            FICHAs = new HashSet<FICHA>();
            HORARIO_CONTA_TREINOs = new HashSet<HORARIO_CONTA_TREINO>();
        }

        public int ID { get; set; }
        public string NOME { get; set; } = null!;
        public string EMAIL { get; set; } = null!;
        public string CPF { get; set; } = null!;
        public decimal? ALTURA { get; set; }
        public string? BIOTIPO { get; set; }
        public DateTime DATA_NASCIMENTO { get; set; }
        public DateTime DATA_CADASTRO { get; set; }
        public DateTime DATA_ATUALIZACAO { get; set; }
        public int ID_USUARIO_CADASTRO { get; set; }

        public virtual ICollection<CONTATO_CONTum> CONTATO_CONTa { get; set; }
        public virtual ICollection<FICHA> FICHAs { get; set; }
        public virtual ICollection<HORARIO_CONTA_TREINO> HORARIO_CONTA_TREINOs { get; set; }
    }
}
