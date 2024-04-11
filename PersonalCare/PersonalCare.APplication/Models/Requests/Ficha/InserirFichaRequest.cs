﻿using PersonalCare.Application.Validation;

namespace PersonalCare.Application.Models.Requests.Ficha
{
    public class InserirFichaRequest
    {
        public InserirFichaRequest()
        {
            ItemFicha = new List<ItemFichaRequest>();
        }

        [Obrigatorio, DataFutura]
        public DateTime DataValidade { get; set; }

        [Obrigatorio]
        public int IdConta { get; set; }

        [Obrigatorio]
        public int IdUsuarioCadastro { get; set; }

        [Obrigatorio]
        public List<ItemFichaRequest> ItemFicha { get; set; }
    }
}
