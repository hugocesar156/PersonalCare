using System;
using System.Collections.Generic;

namespace PersonalCare.DAL.Models.Acesso
{
    public partial class USUARIO_REDEFINICAO_SENHA
    {
        public int ID { get; set; }
        public int ID_USUARIO { get; set; }
        public string CODIGO { get; set; } = null!;
        public DateTime DATA_PEDIDO { get; set; }

        public virtual USUARIO ID_USUARIONavigation { get; set; } = null!;
    }
}
