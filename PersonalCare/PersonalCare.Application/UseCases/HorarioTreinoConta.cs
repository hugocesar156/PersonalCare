using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.HorarioTreino;
using PersonalCare.Application.Models.Responses.HorarioTreino;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.Application.UseCases
{
    public class HorarioTreinoConta : IHorarioTreinoConta
    {
        private readonly IContaRepository _contaRepository;
        private readonly IHorarioTreinoContaRepository _horarioTreinoContaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public HorarioTreinoConta(IContaRepository contaRepository, IHorarioTreinoContaRepository horarioTreinoContaRepository, IUsuarioRepository usuarioRepository)
        {
            _contaRepository = contaRepository;
            _horarioTreinoContaRepository = horarioTreinoContaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public void Atualizar(AtualizarHorarioTreinoRequest request)
        {
            try
            {
                var horarioUsuario = _horarioTreinoContaRepository.VerificaDisponibilidade(request.HoraInicioTimeSpan, request.HoraFimTimeSpan, request.IdUsuario);

                if (horarioUsuario is not null)
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao inserir horário de treino.",
                        $"Já existe um horário definido para o usuário entre " +
                        $"{horarioUsuario.HoraInicio.ToString()[..5]} e {horarioUsuario.HoraFim.ToString()[..5]}",
                        HttpStatusCode.Forbidden);
                }

                if (!_horarioTreinoContaRepository.Atualizar(new HorarioContaTreino(request.Id, request.HoraInicioTimeSpan, request.HoraFimTimeSpan, request.IdUsuario)))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao atualizar horário de treino.",
                        "Registro de horário de treino não encontrado para concluir a ação.",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao atualizar horário de treino.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public HorarioTreinoContaResponse Buscar(int idConta, string idEmpresa)
        {
            try
            {
                var entity = _horarioTreinoContaRepository.Buscar(idConta);

                if (entity is not null)
                {
                    var conta = _contaRepository.Buscar(idConta);
                    var usuario = _usuarioRepository.Buscar(entity.IdUsuario, idEmpresa);

                    return new HorarioTreinoContaResponse(entity.Id, entity.HoraInicio, entity.HoraFim, conta?.Nome ?? string.Empty, usuario?.Nome ?? string.Empty);
                }

                throw new PersonalCareException(
                    "Ocorreu um erro ao buscar horário de treino para a conta.",
                    "Registro de horário de treino não encontrado.", 
                    HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao buscar horário de treino para a conta.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Deletar(int idHorarioTreino)
        {
            try
            {
                if (!_horarioTreinoContaRepository.Deletar(idHorarioTreino))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao deletar horário de treino.",
                        "Registro de horário de treino não encontrado.",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao deletar horário de treino.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Inserir(InserirHorarioTreinoRequest request)
        {
            try
            {
                var horarioUsuario = _horarioTreinoContaRepository.VerificaDisponibilidade(request.HoraInicioTimeSpan, request.HoraFimTimeSpan, request.IdUsuario);

                if (horarioUsuario is not null)
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao inserir horário de treino.",
                        $"Já existe um horário definido para o usuário entre " +
                        $"{horarioUsuario.HoraInicio.ToString()[..5]} e {horarioUsuario.HoraFim.ToString()[..5]}",
                        HttpStatusCode.Forbidden);
                }

                var horarioConta = _horarioTreinoContaRepository.VerificaDisponibilidade(request.IdConta);

                if (horarioConta is not null)
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao inserir horário de treino.",
                        $"Já existe um horário definido para a conta entre " +
                        $"{horarioConta.HoraInicio.ToString()[..5]} e {horarioConta.HoraFim.ToString()[..5]}",
                        HttpStatusCode.Forbidden);
                }

                var entity = new HorarioContaTreino(request.HoraInicioTimeSpan, request.HoraFimTimeSpan, request.IdConta, request.IdUsuario);
                _horarioTreinoContaRepository.Inserir(entity);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao inserir horário de treino.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
