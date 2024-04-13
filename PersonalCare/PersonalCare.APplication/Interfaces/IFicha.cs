﻿using PersonalCare.Application.Models.Requests.Ficha;
using PersonalCare.Application.Models.Responses.Ficha;

namespace PersonalCare.Application.Interfaces
{
    public interface IFicha
    {
        void AtualizarItemFicha(AtualizarItemFichaRequest request);
        FichaResponse BuscarFichaConta(int idConta);
        void Inserir(InserirFichaRequest request);
        void InserirItemFicha(InserirItemFichaRequest request);
        void DeletarItemFicha(int idItemFicha);
    }
}
