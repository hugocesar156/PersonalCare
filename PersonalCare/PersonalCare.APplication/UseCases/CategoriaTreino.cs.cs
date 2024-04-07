using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.CategoriaTreino;
using PersonalCare.Application.Models.Responses.CategoriaTreino;
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

        public void Atualizar(AtualizarCategoriaTreinoRequest request)
        {
            try
            {
                var entity = new Domain.Entities.CategoriaTreino(request.Id, request.Nome);

                if (!_categoriaTreinoRepository.Atualizar(entity))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao atualizar categoria de treino.",
                        "Registro de categoria de treino não encontrado.", 
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao atualizar categoria de treino.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public CategoriaTreinoResponse Buscar(int idCategoriaTreino)
        {
            try
            {
                var categoriaTreino = _categoriaTreinoRepository.Buscar(idCategoriaTreino);

                if (categoriaTreino is not null)
                {
                    return new CategoriaTreinoResponse(categoriaTreino.Id, categoriaTreino.Nome);
                }

                throw new PersonalCareException(
                       "Ocorreu um erro ao buscar categoria de treino.",
                       "Registro de categoria de treino não encontrado.",
                       HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao buscar categoria de treino.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Deletar(int idCategoriaTreino)
        {
            try
            {
                if (!_categoriaTreinoRepository.Deletar(idCategoriaTreino))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao deletar categoria de treino.",
                        "Registro de categoria de treino não encontrado.",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao deletar categoria de treino.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Inserir(InserirCategoriaTreinoRequest request)
        {
            try
            {
                var entity = new Domain.Entities.CategoriaTreino(0, request.Nome);

                if (_categoriaTreinoRepository.Inserir(entity) == 0)
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao inserir categoria de treino.", 
                        null, HttpStatusCode.InternalServerError);
                }
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

        public List<CategoriaTreinoResponse> Listar()
        {
            try
            {
                var entities = _categoriaTreinoRepository.Listar();
                return entities.Select(c => new CategoriaTreinoResponse(c.Id, c.Nome)).ToList();
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao listar categorias de treino.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
