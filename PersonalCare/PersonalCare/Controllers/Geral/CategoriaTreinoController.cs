﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.CategoriaTreino;
using PersonalCare.Application.Models.Responses.CategoriaTreino;
using PersonalCare.Application.Permissoes;
using PersonalCare.Shared;
using System.Net;
using static PersonalCare.Shared.PersonalCareEnums;

namespace PersonalCare.API.Controllers.Geral
{
    [Authorize]
    [ApiController]
    [Route("geral/categoriatreino")]
    [ApiExplorerSettings(GroupName = "geral")]
    public class CategoriaTreinoController : ControllerBase
    {
        private readonly ICategoriaTreino _categoriaTreino;

        public CategoriaTreinoController(ICategoriaTreino categoriaTreino)
        {
            _categoriaTreino = categoriaTreino;
        }

        /// <summary>
        /// Atualiza uma categoria de treino.
        /// </summary>
        [HttpPut("atualizar")]
        [PermissaoUsuario(Entidade.CategoriaTreino, Acao.Atualizar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Atualizar(AtualizarCategoriaTreinoRequest request)
        {
            try
            {
                _categoriaTreino.Atualizar(request);
                return StatusCode((int)HttpStatusCode.OK, "Categoria de treino atualizada com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Retorna uma categoria de treino a partir do ID informado.
        /// </summary>
        [HttpGet("buscar/{idCategoriaTreino}")]
        [PermissaoUsuario(Entidade.CategoriaTreino, Acao.Visualizar)]
        [ProducesResponseType(typeof(CategoriaTreinoResponse), StatusCodes.Status200OK)]
        public IActionResult Buscar(int idCategoriaTreino)
        {
            try
            {
                var categoriaTreino = _categoriaTreino.Buscar(idCategoriaTreino);
                return StatusCode((int)HttpStatusCode.OK, categoriaTreino);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Deleta uma categoria de treino a partir do ID informado.
        /// </summary>
        [HttpDelete("deletar/{idCategoriaTreino}")]
        [PermissaoUsuario(Entidade.CategoriaTreino, Acao.Deletar)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Deletar(int idCategoriaTreino)
        {
            try
            {
                _categoriaTreino.Deletar(idCategoriaTreino);
                return StatusCode((int)HttpStatusCode.OK, "Categoria de treino deletada com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Insere uma categoria de treino.
        /// </summary>
        [HttpPost("inserir")]
        [PermissaoUsuario(Entidade.CategoriaTreino, Acao.Inserir)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Inserir(InserirCategoriaTreinoRequest request)
        {
            try
            {
                _categoriaTreino.Inserir(request);
                return StatusCode((int)HttpStatusCode.OK, "Categoria de treino inserida com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }

        /// <summary>
        /// Retona a lista de categorias de treino.
        /// </summary>
        [HttpGet("listar")]
        [PermissaoUsuario(Entidade.CategoriaTreino, Acao.Visualizar)]
        [ProducesResponseType(typeof(List<CategoriaTreinoResponse>), StatusCodes.Status200OK)]
        public IActionResult Listar()
        {
            try
            {
                var lista = _categoriaTreino.Listar();
                return StatusCode((int)HttpStatusCode.OK, lista);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}
