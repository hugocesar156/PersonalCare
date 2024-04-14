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
        private readonly IUsuarioRepository _usuarioRepository;

        public Usuario(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }

        public void AdicionarPermissoes(AdicionarPermissaoRequest request, string idEmpresa)
        {
            try
            {
                var usuario = _usuarioRepository.Buscar(request.IdUsuario, idEmpresa);

                if (usuario is not null)
                {
                    var entity = request.Permissoes.Select(p => new PermissaoUsuario(request.IdUsuario,
                        new Entidade(p.IdEntidade), new Acao(p.IdAcao))).ToList();

                    usuario.Permissoes.ForEach(up =>
                    {
                        var permissao = entity.FirstOrDefault(p => p.Entidade.Id == up.Entidade.Id && p.Acao.Id == up.Acao.Id);

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

                    if (!_usuarioRepository.AdicionarPermissoes(entity))
                    {
                        throw new PersonalCareException(
                            "Ocorreu um erro ao atualizar as permissões do usuário.",
                            null, HttpStatusCode.InternalServerError);
                    }
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

        public AutenticarResponse Autenticar(AutenticarRequest request)
        {
            try 
            {
                var entity = _usuarioRepository.BuscarPorEmail(request.Email, request.IdEmpresa);

                if (entity is not null)
                {
                    if (CriptografiaService.VerificarSenha(request.Senha, entity.Salt, entity.Senha))
                    {
                        return new AutenticarResponse(entity.Nome, TokenService.GerarToken(entity, request.IdEmpresa, _configuration["JWTSigningKey"]));
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

                if (_usuarioRepository.Cadastrar(entity) == 0)
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao cadastrar usuário.", 
                        null, HttpStatusCode.InternalServerError);
                }
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
    }
}
