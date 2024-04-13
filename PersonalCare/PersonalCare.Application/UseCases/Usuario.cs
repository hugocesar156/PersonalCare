using Microsoft.Extensions.Configuration;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Usuario;
using PersonalCare.Application.Models.Responses.Usuario;
using PersonalCare.Application.Services;
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

        public AutenticarResponse Autenticar(AutenticarRequest request)
        {
            try 
            {
                var entity = _usuarioRepository.BuscarPorEmail(request.Email);

                if (entity is not null)
                {
                    if (CriptografiaService.VerificarSenha(request.Senha, entity.Salt, entity.Senha))
                    {
                        return new AutenticarResponse(entity.Nome, TokenService.GerarToken(entity, _configuration["JWTSigningKey"]));
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

        public void Cadastrar(CadastrarUsuarioRequest request)
        {
            try
            {
                if (_usuarioRepository.EmailCadastrado(request.Email))
                {
                    throw new PersonalCareException(
                        "Ocorreu um erro ao cadastrar usuário.",
                        "Email informado já cadastrado para outro usuário.", 
                        HttpStatusCode.Forbidden);
                }

                var (senha, salt) = CriptografiaService.CriptografarSenha(request.Senha);
                var entity = new Domain.Entities.Usuario(request.Nome, request.Email, senha, salt);

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
