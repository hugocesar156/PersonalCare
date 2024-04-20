using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Empresarial
{
    public partial class EMPRESA
    {
        public EMPRESA()
        {
            EMPRESA_CONTATOs = new HashSet<EMPRESA_CONTATO>();
            EMPRESA_EMAILs = new HashSet<EMPRESA_EMAIL>();
            EMPRESA_MIDIASOCIALs = new HashSet<EMPRESA_MIDIASOCIAL>();
        }

        public int ID { get; set; }
        public string GUID { get; set; } = null!;
        public string RAZAO_SOCIAL { get; set; } = null!;
        public string NOME_FANTASIA { get; set; } = null!;
        public string CNPJ { get; set; } = null!;
        public string CEP { get; set; } = null!;
        public string NUMERO { get; set; } = null!;
        public string LOGRADOURO { get; set; } = null!;
        public string BAIRRO { get; set; } = null!;
        public string CIDADE { get; set; } = null!;
        public string UF { get; set; } = null!;

        public virtual ICollection<EMPRESA_CONTATO> EMPRESA_CONTATOs { get; set; }
        public virtual ICollection<EMPRESA_EMAIL> EMPRESA_EMAILs { get; set; }
        public virtual ICollection<EMPRESA_MIDIASOCIAL> EMPRESA_MIDIASOCIALs { get; set; }
    }
}
