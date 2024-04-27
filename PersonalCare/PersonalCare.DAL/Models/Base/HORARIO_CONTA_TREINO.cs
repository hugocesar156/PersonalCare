using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Base
{
    public partial class HORARIO_CONTA_TREINO
    {
        public int ID { get; set; }
        public TimeSpan HORA_INICIO { get; set; }
        public TimeSpan HORA_FIM { get; set; }
        public int ID_CONTA { get; set; }
        public int ID_USUARIO { get; set; }

        public virtual CONTum ID_CONTANavigation { get; set; } = null!;
    }
}
