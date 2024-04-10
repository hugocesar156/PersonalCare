﻿using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Ficha;
using PersonalCare.Domain.Interfaces;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.Application.UseCases
{
    public class Ficha : IFicha
    {
        private readonly IFichaRepository _fichaRepository;

        public Ficha(IFichaRepository fichaRepository)
        {
            _fichaRepository = fichaRepository;
        }

        public void Inserir(InserirFichaRequest request)
        {
            try
            {
                var entity = new Domain.Entities.Ficha(
                    0, 
                    DateTime.Now, 
                    request.DataValidade, 
                    request.IdConta, 
                    request.IdUsuarioCadastro, 
                    request.ItemFicha.Select(i => new Domain.Entities.ItemFicha(
                        0, 
                        i.Series,
                        i.Repeticoes, 
                        0, 
                        i.IdTreino)).ToList());

                if (_fichaRepository.Inserir(entity) == 0)
                {

                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao inserir registro de ficha", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
