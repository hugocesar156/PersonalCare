using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.CategoriaTreino;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.API.Controllers.CategoriaTreino
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaTreinoController : ControllerBase
    {
        private readonly ICategoriaTreino _categoriaTreino;

        public CategoriaTreinoController(ICategoriaTreino categoriaTreino)
        {
            _categoriaTreino = categoriaTreino;
        }

        /// <summary>
        /// Insere uma categoria de treino.
        /// </summary>
        [HttpPost("Inserir")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Inserir(InserirCategoriaTreinoRequest request)
        {
            try
            {
                _categoriaTreino.Inserir(request);
                return StatusCode((int)HttpStatusCode.OK, "Categoria de treino adicionada com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}
