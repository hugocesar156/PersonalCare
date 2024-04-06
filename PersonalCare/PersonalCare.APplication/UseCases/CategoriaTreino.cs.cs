using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.CategoriaTreino;
using PersonalCare.Domain.Interfaces;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.Application.UseCases
{
    public class CategoriaTreino : ICategoriaTreino
    {
        private readonly ICategoriaTreinoRepository _categoriaTreinoRepository;

        public CategoriaTreino(ICategoriaTreinoRepository categoriaTreinoRepository)
        {
            _categoriaTreinoRepository = categoriaTreinoRepository;
        }

        public void Inserir(InserirCategoriaTreinoRequest request)
        {
            try
            {
                var entity = new Domain.Entities.CategoriaTreino(0, request.Nome);
                _categoriaTreinoRepository.Inserir(entity);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao inserir categoria de treino.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
