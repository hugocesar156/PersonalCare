using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Conta;
using PersonalCare.Application.Models.Requests.HorarioTreino;
using PersonalCare.Application.Models.Responses.Conta;
using PersonalCare.Application.Models.Responses.HorarioTreino;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.Application.UseCases
{
    public class Conta : IConta
    {
        private readonly IContaRepository _contaRepository;

        public Conta(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public void Atualizar(AtualizarContaRequest request)
        {
            try
            {
                var entity = new Domain.Entities.Conta(
                    request.Id,
                    request.Nome,
                    request.Email,
                    request.Cpf,
                    request.Altura,
                    request.Biotipo,
                    request.DataNascimento);

                var (cpf, email) = _contaRepository.BuscarDadosExistentes(entity.Cpf, entity.Email, entity.Id);

                if (!string.IsNullOrEmpty(cpf) || !string.IsNullOrEmpty(email))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao atualizar registro de conta",
                        entity.Cpf.Equals(cpf) ?
                            $"O CPF '{entity.Cpf}' já está registrado para uma outra conta." :
                            $"O e-mail '{entity.Email}' já está registrado para uma outra conta.",
                        HttpStatusCode.Forbidden);
                }

                if (!_contaRepository.Atualizar(entity))
                {
                    throw new PersonalCareException(
                        "Não foi possível atualizar informações da conta.",
                        "Registro de conta não encontrado no servidor.",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao atualizar registro de conta.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void AtualizarContato(AtualizarContaContatoRequest request)
        {
            try
            {
                var entity = new ContatoConta(request.Id, request.Nome, request.Numero, request.Ddd, request.Ddi);

                if (!_contaRepository.AtualizarContato(entity))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao atualizar contato do registro de conta.",
                        "Registro de conta não encontrado para concluir a ação.",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao atualizar contato do registro de conta.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public ContaResponse Buscar(int idConta)
        {
            try
            {
                var conta = _contaRepository.Buscar(idConta);

                if (conta is not null)
                {
                    return new ContaResponse(
                        conta.Id,
                        conta.Nome,
                        conta.Email,
                        conta.Cpf,
                        conta.Altura,
                        conta.Biotipo,
                        conta.DataNascimento,
                        conta.Contatos);
                }

                throw new PersonalCareException(
                    "Não foi possível buscar informações da conta.",
                    "Registro de conta não encontrado no servidor.",
                    HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao buscar registro de conta.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Deletar(int idConta)
        {
            try
            {
                if (!_contaRepository.Deletar(idConta))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao deletar registro de conta.",
                        "Registro de conta não encontrado para concluir a ação.",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao deletar registro de conta.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void DeletarContato(int idContato)
        {
            try
            {
                if (!_contaRepository.DeletarContato(idContato))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao deletar contato do registro de conta.",
                        "Contato não encontrado para concluir a ação.",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao deletar contato do registro de conta.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Inserir(InserirContaRequest request, int idUsuario)
        {
            try
            {
                var entity = new Domain.Entities.Conta(
                    request.Nome,
                    request.Email,
                    request.Cpf,
                    request.Altura,
                    request.Biotipo,
                    request.DataNascimento,
                    idUsuario);

                var (cpf, email) = _contaRepository.BuscarDadosExistentes(entity.Cpf, entity.Email);

                if (!string.IsNullOrEmpty(cpf) || !string.IsNullOrEmpty(email))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao inserir registro de conta",
                        entity.Cpf.Equals(cpf) ?
                            $"O CPF '{entity.Cpf}' já está registrado para uma outra conta." :
                            $"O e-mail '{entity.Email}' já está registrado para uma outra conta.",
                        HttpStatusCode.Forbidden);
                }

                var idConta = _contaRepository.Inserir(entity);

                if (request.ContatoConta != null && request.ContatoConta.Any())
                {
                    var entities = request.ContatoConta.Select(c => new Domain.Entities.ContatoConta(c.Nome, c.Numero, c.Ddd, c.Ddi, idConta)).ToList();
                    _contaRepository.InserirContato(entities);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao inserir registro de conta", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void InserirContato(InserirContaContatoRequest request)
        {
            try
            {
                var entity = new Domain.Entities.ContatoConta(request.Nome, request.Numero, request.Ddd, request.Ddi, request.IdConta);

                if (!_contaRepository.InserirContato(entity))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao adicionar contato para a conta.",
                        "Registro de conta não encontrado para concluir a ação.",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao adicionar contato para a conta.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public List<ContaResponse> Listar()
        {
            try
            {
                var contas = _contaRepository.Listar();
                return contas.Select(c => new ContaResponse(c.Id, c.Nome, c.Email, c.Cpf, c.Altura, c.Biotipo, c.DataNascimento, c.Contatos)).ToList();
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao listar registro de contas.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
