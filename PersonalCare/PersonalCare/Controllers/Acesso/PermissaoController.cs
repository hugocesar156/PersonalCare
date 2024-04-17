﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Usuario;
using PersonalCare.Application.Permissoes;
using PersonalCare.Shared;
using System.Net;
using System.Security.Claims;
using static PersonalCare.Shared.PersonalCareEnums;

namespace PersonalCare.API.Controllers.Acesso
{
    [ApiController]
    [Route("acesso/permissao")]
    [ApiExplorerSettings(GroupName = "acesso")]
    public class PermissaoController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public PermissaoController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        /// <summary>
        /// Adiciona permissões do sistema para um usuário.
        /// </summary>
        [HttpPost("adicionar")]
        [Authorize, Permissao(Entidade.Usuario, Acao.Atualizar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Adicionar(AdicionarPermissaoRequest request)
        {
            try
            {
                _usuario.AdicionarPermissoes(request, HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA));
                return StatusCode((int)HttpStatusCode.OK, "As permissões de usuário foram atualizadas.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Remove permissões do sistema para um usuário.
        /// </summary>
        [HttpDelete("remover")]
        [Authorize, Permissao(Entidade.Usuario, Acao.Atualizar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Remover(RemoverPermissaoRequest request)
        {
            try
            {
                _usuario.RemoverPermissoes(request, HttpContext.User.FindFirstValue(PersonalCareClaims.ID_EMPRESA));
                return StatusCode((int)HttpStatusCode.OK, "As permissões de usuário foram atualizadas.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}