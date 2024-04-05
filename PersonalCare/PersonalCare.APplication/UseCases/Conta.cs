using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Conta;
using PersonalCare.Application.Models.Responses.Conta;
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

        public ContaResponse Inserir(ContaRequest request)
        {
            try
            {
                var entity = new Domain.Entities.Conta(
                    0,
                    request.Nome,
                    request.Email,
                    request.Cpf,
                    request.Altura,
                    request.Biotipo,
                    request.DataNascimento,
                    DateTime.Now,
                    DateTime.Now,
                    request.IdUsuarioCadastro,
                    new List<Domain.Entities.ContatoConta>());

                if (_contaRepository.Buscar(entity.Cpf) is not null)
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao inserir registro de conta", 
                        $"O CPF '{entity.Cpf}' já está registrado para uma outra conta.", 
                        HttpStatusCode.Forbidden);
                }

                var idConta = _contaRepository.Inserir(entity);

                if (request.ContatoConta != null && request.ContatoConta.Any())
                    _contaRepository.InserirContato(request.ContatoConta.Select(c => new Domain.Entities.ContatoConta(0, c.Nome, c.Numero, c.Ddd, c.Ddi, idConta)).ToList());

                var conta = _contaRepository.Buscar(idConta);

                return new ContaResponse(
                    conta.Id,
                    conta.Nome,
                    conta.Email,
                    conta.Cpf,
                    conta.Altura,
                    conta.Biotipo,
                    conta.DataNascimento,
                    new List<Domain.Entities.ContatoConta>());
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao inserir registro de conta", ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        public List<ContaResponse> Listar()
        {
            try
            {
                var contas = _contaRepository.Listar();
                return contas.Select(c => new ContaResponse(c.Id, c.Nome, c.Email, c.Cpf, c.Altura, c.Biotipo, c.DataNascimento, c.Contatos)).ToList();
            }
            catch (Exception ex)
            {

            }

            throw new NotImplementedException();
        }
    }
}
