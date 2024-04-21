using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Ficha;
using PersonalCare.Application.Models.Responses.CategoriaTreino;
using PersonalCare.Application.Models.Responses.Ficha;
using PersonalCare.Application.Models.Responses.Treino;
using PersonalCare.Application.Services;
using PersonalCare.Domain.Interfaces;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.Application.UseCases
{
    public class Ficha : IFicha
    {
        private readonly IContaRepository _contaRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IFichaRepository _fichaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public Ficha(IContaRepository contaRepository, IEmpresaRepository empresaRepository, IFichaRepository fichaRepository, IUsuarioRepository usuarioRepository)
        {
            _contaRepository = contaRepository;
            _empresaRepository = empresaRepository;
            _fichaRepository = fichaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public void Atualizar(AtualizarFichaRequest request)
        {
            try
            {
                var entity = new Domain.Entities.Ficha(request.Id, request.DataValidade);

                if (!_fichaRepository.Atualizar(entity))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao atualizar registro de ficha.", 
                        "Registro de ficha não encontrado.",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao atualizar registro de ficha.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void AtualizarItemFicha(AtualizarItemFichaRequest request)
        {
            try
            {
                var entity = new Domain.Entities.ItemFicha(request.Id, request.Grupo, request.Series, request.Repeticoes, 
                    new Domain.Entities.Treino(request.IdTreino));

                if (!_fichaRepository.AtualizarItemFicha(entity))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao atualizar treino para a ficha.", 
                        "O treino de ficha não foi encontrado.", 
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao atualizar treino para a ficha.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
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
                    "Ocorreu um erro ao buscar registro de ficha.", 
                    "Registro de ficha não encontrado.", 
                    HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao buscar registro de ficha.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Deletar(int idFicha)
        {
            try
            {
                if (!_fichaRepository.Deletar(idFicha))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao deletar registro de ficha.",
                        "Registro de ficha não encontrado.",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao deletar registro de ficha.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void DeletarItemFicha(int idItemFicha)
        {
            try
            {
                if (!_fichaRepository.DeletarItemFicha(idItemFicha))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao remover treino da ficha.",
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
                throw new PersonalCareException("Ocorreu um erro ao remover treino da ficha.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void EnviarFichaPorEmail(int idFicha, string idEmpresa)
        {
            try
            {
                var ficha = _fichaRepository.Buscar(idFicha);

                if (ficha is not null)
                {
                    var empresa = _empresaRepository.Buscar(idEmpresa);

                    if (empresa is not null && empresa.Email is not null)
                    {
                        var conta = _contaRepository.Buscar(ficha.IdConta);
                        var usuario = _usuarioRepository.Buscar(ficha.IdUsuarioCadastro, idEmpresa);

                        if (conta is not null)
                        {
                            var template = TemplateService.TemplateFicha(ficha, conta.Nome, usuario?.Nome ?? string.Empty, empresa.NomeFantasia);
                            EmailService.EnviarEmail(empresa.Email, conta.Email, "Envio de ficha de treino.", template);
                        }
                    }
                    else
                        throw new PersonalCareException(
                            "Ocorreu um erro ao enviar ficha por email.",
                            "As configurações da empresa não estão definidas corretamente para realizar a ação, entre em contato com os responsáveis.",
                            HttpStatusCode.InternalServerError);
                }
                else
                    throw new PersonalCareException(
                        "Ocorreu um erro ao enviar ficha por email.", 
                        "Registro de ficha não encontrado.", 
                        HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao enviar ficha por email.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Inserir(InserirFichaRequest request, int idUsuario)
        {
            try
            {
                var entity = new Domain.Entities.Ficha(
                    request.DataValidade, 
                    request.IdConta,
                    idUsuario, 
                    request.ItemFicha.Select(i => new Domain.Entities.ItemFicha(
                        i.Grupo,
                        i.Series,
                        i.Repeticoes, 
                        new Domain.Entities.Treino(i.IdTreino))).ToList());

                _fichaRepository.Inserir(entity);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao inserir registro de ficha.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void InserirItemFicha(InserirItemFichaRequest request)
        {
            try
            {
                var entity = new Domain.Entities.ItemFicha(request.Grupo, request.Series, request.Repeticoes, request.IdFicha, 
                    new Domain.Entities.Treino(request.IdTreino));

                _fichaRepository.InserirItemFicha(entity);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao inserir novo item para a ficha de treino.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
