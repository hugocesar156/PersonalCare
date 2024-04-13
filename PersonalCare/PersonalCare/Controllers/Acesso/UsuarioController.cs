﻿using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Usuario;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.API.Controllers.Acesso
{
    [ApiController]
    [Route("acesso/[controller]")]
    [ApiExplorerSettings(GroupName = "acesso")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        /// <summary>
        /// Cadastra um usuário.
        /// </summary>
        [HttpPost("cadastrar")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Cadastrar(CadastrarUsuarioRequest request)
        {
            try
            {
                _usuario.Cadastrar(request);
                return StatusCode((int)HttpStatusCode.OK, "Usuário cadastrado com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}