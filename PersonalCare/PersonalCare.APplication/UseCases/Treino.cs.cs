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
            throw new NotImplementedException();
        }

        public TreinoResponse Buscar(int idTreino)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idTreino)
        {
            throw new NotImplementedException();
        }

        public void Inserir(InserirTreinoRequest request)
        {
            try
            {
                var entity = new Domain.Entities.Treino(0, request.Nome, request.Descricao, new Domain.Entities.CategoriaTreino(request.IdCategoriaTreino, ""));

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

        public List<TreinoResponse> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
