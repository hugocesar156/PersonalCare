﻿using Microsoft.Extensions.Configuration;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Usuario;
using PersonalCare.Application.Models.Responses.Usuario;
using PersonalCare.Application.Services;
using PersonalCare.Domain.Entities;
using PersonalCare.Domain.Interfaces;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.Application.UseCases
{
    public class Usuario : IUsuario
    {
        private readonly IConfiguration _configuration;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public Usuario(IConfiguration configuration, IEmpresaRepository empresaRepository, IUsuarioRepository usuarioRepository)
        {
            _configuration = configuration;
            _empresaRepository = empresaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public void AdicionarPermissoes(AdicionarPermissaoRequest request, string idEmpresa)
        {
            try
            {
                var usuario = _usuarioRepository.Buscar(request.IdUsuario, idEmpresa);

                if (usuario is not null)
                {
                    var entity = request.Permissoes.Select(p => new PermissaoUsuario(request.IdUsuario, new Permissao(p))).ToList();

                    usuario.Permissoes.ForEach(up =>
                    {
                        var permissao = entity.FirstOrDefault(p => p.Permissao.Id == up.Permissao.Id);

                        if (permissao is not null)
                            entity.Remove(permissao);
                    });

                    if (!entity.Any())
                    {
                        throw new PersonalCareException(
                            "Ocorreu um erro ao atualizar as permissões do usuário.",
                            "Não há permissões novas recebidas para serem adicionadas ao usuário",
                            HttpStatusCode.Forbidden);
                    }

                    _usuarioRepository.AdicionarPermissoes(entity);
                }
                else 
                    throw new PersonalCareException(
                        "Ocorreu um erro ao atualizar as permissões do usuário.",
                        "Registro de usuário não encontrado.",
                        HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao atualizar as permissões do usuário.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void AlterarSenha(AlterarSenhaRequest request, int idUsuario, string idEmpresa)
        {
            try
            {
                var usuario = _usuarioRepository.Buscar(idUsuario, idEmpresa);

                if (usuario is not null)
                {
                    var (senha, salt) = CriptografiaService.CriptografarSenha(request.Senha);

                    var entity = new Domain.Entities.Usuario(idUsuario, senha, salt, idEmpresa);

                    if (!_usuarioRepository.AlterarSenha(entity))
                    {
                        throw new PersonalCareException(
                            "Ocorreu um erro ao alterar senha do usuário.",
                            null, HttpStatusCode.InternalServerError);
                    }
                }
                else
                    throw new PersonalCareException(
                        "Ocorreu um erro ao alterar senha do usuário.", 
                        "Registro de usuário não encontrado.", 
                        HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao alterar senha do usuário.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Atualizar(AtualizarUsuarioRequest request, string idEmpresa)
        {
            try
            {
                if (_usuarioRepository.EmailCadastrado(request.Email, idEmpresa, request.Id))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao atualizar dados usuário.",
                        "Email informado já cadastrado para outro usuário.",
                        HttpStatusCode.Forbidden);
                }

                var entity = new Domain.Entities.Usuario(request.Id, request.Nome, request.Email, request.Ativo, idEmpresa);

                if (!_usuarioRepository.Atualizar(entity))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao atualizar dados usuário.",
                        "Registro de usuário não encontrado.",
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao atualizar dados usuário.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public AutenticarResponse Autenticar(AutenticarRequest request)
        {
            try 
            {
                var entity = _usuarioRepository.BuscarPorEmail(request.Email, request.IdEmpresa);

                if (entity is not null)
                {
                    if (CriptografiaService.VerificarSenha(request.Senha, entity.Salt, entity.Senha))
                    {
                        if (entity.Ativo)
                        {
                            _usuarioRepository.RegistrarAcesso(entity.Id);
                            return new AutenticarResponse(entity.Nome, TokenService.GerarTokenAutenticacaoUsuario(entity, request.IdEmpresa, _configuration["JWTSigningKey"]));
                        }

                        throw new PersonalCareException(
                            "Ocorreu um erro ao autenticar usuário.",
                            "Usuário não está ativo na base, entre em contato com os responsáveis para informações.",
                            HttpStatusCode.Forbidden);
                    }

                    throw new PersonalCareException(
                        "Ocorreu um erro ao autenticar usuário.",
                        "Senha informada inválida.",
                        HttpStatusCode.Forbidden);
                }

                throw new PersonalCareException(
                    "Ocorreu um erro ao autenticar usuário.", 
                    "Email informado inválido.", 
                    HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao autenticar usuário.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public UsuarioResponse Buscar(int idUsuario, string idEmpresa)
        {
            try
            {
                var entity = _usuarioRepository.Buscar(idUsuario, idEmpresa); 

                if (entity is not null)
                {
                    return new UsuarioResponse(entity.Id, entity.Nome, entity.Email, entity.Ativo, entity.DataCadastro, entity.DataAtaualizacao, entity.DataUltimoAcesso, entity.Permissoes);
                }

                throw new PersonalCareException(
                    "Ocorreu um erro ao buscar registro de usuário.",
                    "Registro de usuário não foi encontrado no servidor", 
                    HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao buscar registro de usuário.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Cadastrar(CadastrarUsuarioRequest request, string idEmpresa)
        {
            try
            {
                if (_usuarioRepository.EmailCadastrado(request.Email, idEmpresa))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao cadastrar usuário.",
                        "Email informado já cadastrado para outro usuário.", 
                        HttpStatusCode.Forbidden);
                }

                var (senha, salt) = CriptografiaService.CriptografarSenha(request.Senha);
                var entity = new Domain.Entities.Usuario(request.Nome, request.Email, senha, salt, idEmpresa);

                _usuarioRepository.Cadastrar(entity);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao cadastrar usuário.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void Deletar(int idUsuario, string idEmpresa)
        {
            try
            {
                if (!_usuarioRepository.Deletar(idUsuario, idEmpresa))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao deletar registro de usuário.", 
                        "Registro de usuário não encontrado.", 
                        HttpStatusCode.NotFound);
                }
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao deletar registro de usuário.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void EnviarEmailRedefinicaoSenha(RedefinicaoSenhaRequest request)
        {
            try
            {
                var usuario = _usuarioRepository.BuscarPorEmail(request.Email, request.IdEmpresa);

                if (usuario is not null)
                {
                    var empresa = _empresaRepository.Buscar(request.IdEmpresa);

                    if (empresa is not null && empresa.Email is not null)
                    {
                        var (template, codigoVerificacao) = TemplateService.TemplateRedefinicaoSenha(empresa.NomeFantasia);

                        EmailService.EnviarEmail(empresa.Email, request.Email, "Redefinição de senha de usuário", template, null);

                        var entity = new RedefinicaoSenhaUsuario(usuario.Id, codigoVerificacao);
                        _usuarioRepository.RegistrarEnvioRedeficicaoSenha(entity);
                    }
                    else
                        throw new PersonalCareException(
                            "Ocorreu um erro ao enviar email de redefinição de senha de usuário.",
                            "As configurações da empresa não estão definidas corretamente para realizar a ação, entre em contato com os responsáveis.",
                            HttpStatusCode.InternalServerError);
                }
                else
                    throw new PersonalCareException(
                        "Ocorreu um erro ao enviar email de redefinição de senha de usuário.", 
                        "Email não encontrado no sistema", 
                        HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao enviar email de redefinição de senha de usuário.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public List<ListarUsuarioResponse> Listar(string idEmpresa)
        {
            try
            {
                var entities = _usuarioRepository.Listar(idEmpresa);
                return entities.Select(u => new ListarUsuarioResponse(u.Id, u.Nome, u.Email, u.Ativo, u.DataCadastro, u.DataAtaualizacao, u.DataUltimoAcesso)).ToList();
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao listar registro de usuários.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public List<PermissaoResponse> ListarPermissoes()
        {
            try
            {
                var entities = _usuarioRepository.ListarPermissoes();
                return entities.Select(p => new PermissaoResponse(p.Id, p.Nome, p.Descricao)).ToList();
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao listar as permissões do sistema.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public void RemoverPermissoes(RemoverPermissaoRequest request, string idEmpresa)
        {
            try
            {
                var usuario = _usuarioRepository.Buscar(request.IdUsuario, idEmpresa);

                if (usuario is not null)
                {
                    request.Permissoes.ForEach(p =>
                    {
                        if (!usuario.Permissoes.Select(up => up.Id).Contains(p))
                        {
                            throw new PersonalCareException(
                                "Ocorreu um erro ao atualizar as permissões do usuário.",
                                "Uma ou mais permissoes informadas não fazem parte das permissões do usuário.",
                                HttpStatusCode.Forbidden);
                        }
                    });

                    _usuarioRepository.RemoverPermissoes(request.IdUsuario, request.Permissoes);
                }
                else
                    throw new PersonalCareException(
                        "Ocorreu um erro ao atualizar as permissões do usuário.",
                        "Registro de usuário não encontrado.",
                        HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro ao atualizar as permissões do usuário.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }

        public ValidarCodigoResponse ValidarCodigoVerificacao(ValidarCodigoRequest request)
        {
            try
            {
                var usuario = _usuarioRepository.BuscarPorEmail(request.Email, request.IdEmpresa);

                if (usuario is not null)
                {
                    if (_usuarioRepository.ValidarCodigoVerificacao(usuario.Id, request.Codigo))
                    {
                        var token = TokenService.GerarTokenRedefinicaoSenha(usuario.Id, request.IdEmpresa, _configuration["JWTSigningKey"]);
                        return new ValidarCodigoResponse(token, DateTime.Now.AddMinutes(10));
                    }
                    else
                        throw new PersonalCareException(
                            "Ocorreu um erro durante a validação.",
                            "O código de verificação não foi validado.", 
                            HttpStatusCode.InternalServerError);
                }
                else
                    throw new PersonalCareException(
                        "Ocorreu um erro durante a validação.", 
                        "Registro de usuário não encontrado.", 
                        HttpStatusCode.NotFound);
            }
            catch (PersonalCareException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new PersonalCareException("Ocorreu um erro durante a validação.", ex?.InnerException?.Message ?? ex?.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
