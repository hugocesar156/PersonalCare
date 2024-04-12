using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Treino;
using PersonalCare.Application.Models.Responses.Treino;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.Application.UseCases
{
    public class Treino : ITreino
    {
        private readonly ITreinoRepository _treinoRepository;

        public Treino(ITreinoRepository treinoRepository)
        {
            _treinoRepository = treinoRepository;
        }

        public void Atualizar(AtualizarTreinoRequest request)
        {
            try
            {
                var entity = new Domain.Entities.Treino(request.Id, request.Nome, request.Descricao, new Domain.Entities.CategoriaTreino(request.IdCategoriaTreino));

                if (!_treinoRepository.Atualizar(entity))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao atualizar registro de treino",
                        "O registro de treino não foi encontrado",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao atualizar registro de treino", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public TreinoResponse Buscar(int idTreino)
        {
            try
            {
                var entity = _treinoRepository.Buscar(idTreino);

                if (entity is not null)
                {
                    return new TreinoResponse(entity.Id, entity.Nome, entity.Descricao, new Domain.Entities.CategoriaTreino(entity.Categoria.Id, entity.Categoria.Nome));
                }

                throw new PersonalCareException(
                    "Ocorreu um erro ao buscar registro de treino",
                    "O registro de treino não foi encontrado",
                    HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao buscar registro de treino.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Deletar(int idTreino)
        {
            try
            {
                if (!_treinoRepository.Deletar(idTreino))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao deletar registro de treino",
                        "O registro de treino não foi encontrado",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao deletar registro de treino.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Inserir(InserirTreinoRequest request)
        {
            try
            {
                var entity = new Domain.Entities.Treino(request.Nome, request.Descricao, new Domain.Entities.CategoriaTreino(request.IdCategoriaTreino));

                if (_treinoRepository.Inserir(entity) == 0)
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao inserir registro de treino", 
                        null, HttpStatusCode.InternalServerError);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao inserir registro de treino", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public List<TreinoResponse> Listar(int idCategoriaTreino = 0)
        {
            try
            {
                var lista = _treinoRepository.Listar(idCategoriaTreino);
                return lista.Select(t => new TreinoResponse(t.Id, t.Nome, t.Descricao, new Domain.Entities.CategoriaTreino(t.Categoria.Id, t.Categoria.Nome))).ToList();
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao listar treinos.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
