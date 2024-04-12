using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Ficha;
using PersonalCare.Application.Models.Responses.CategoriaTreino;
using PersonalCare.Application.Models.Responses.Ficha;
using PersonalCare.Application.Models.Responses.Treino;
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

        public FichaResponse BuscarFichaConta(int idConta)
        {
            try
            {
                var entity = _fichaRepository.BuscarPorConta(idConta);

                if (entity is not null)
                {
                    return new FichaResponse(entity.Id, entity.DataCriacao, entity.DataValidade, entity.IdConta, entity.IdUsuarioCadastro, entity.ItemFicha);
                }

                throw new PersonalCareException(
                    "Ocorreu um erro ao buscar registro de ficha", 
                    "Registro de ficha não encontrado", 
                    HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao buscar registro de ficha", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void DeletarItemFicha(int idItemFicha)
        {
            try
            {
                if (!_fichaRepository.DeletarItemFicha(idItemFicha))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao remover treino da ficha",
                        "Registro de treino para a ficha não encontrado.",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao remover treino da ficha", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Inserir(InserirFichaRequest request)
        {
            try
            {
                var entity = new Domain.Entities.Ficha(
                    request.DataValidade, 
                    request.IdConta, 
                    request.IdUsuarioCadastro, 
                    request.ItemFicha.Select(i => new Domain.Entities.ItemFicha(
                        i.Grupo,
                        i.Series,
                        i.Repeticoes, 
                        new Domain.Entities.Treino(i.IdTreino))).ToList());

                if (_fichaRepository.Inserir(entity) == 0)
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao inserir registro de ficha",
                        null, HttpStatusCode.InternalServerError);
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

        public void InserirItemFicha(InserirItemFichaRequest request)
        {
            try
            {
                var entity = new Domain.Entities.ItemFicha(request.Grupo, request.Series, request.Repeticoes, request.IdFicha, 
                    new Domain.Entities.Treino(request.IdTreino));

                if (_fichaRepository.InserirItemFicha(entity) == 0)
                {
                    throw new PersonalCareException(
                       "Ocorreu um erro ao inserir novo item para a ficha de treino",
                       null, HttpStatusCode.InternalServerError);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao inserir novo item para a ficha de treino", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
