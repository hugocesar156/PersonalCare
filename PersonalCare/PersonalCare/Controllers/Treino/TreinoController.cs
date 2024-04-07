using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Treino;
using PersonalCare.Shared;
using System.Net;

namespace PersonalCare.API.Controllers.Treino
{
    [ApiController]
    [Route("[controller]")]
    public class TreinoController : ControllerBase
    {
        private readonly ITreino _treino;

        public TreinoController(ITreino treino)
        {
            _treino = treino;
        }

        /// <summary>
        /// Insere um registro de treino.
        /// </summary>
        [HttpPost("Inserir")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Inserir(InserirTreinoRequest request)
        {
            try
            {
                _treino.Inserir(request);
                return StatusCode((int)HttpStatusCode.OK, "Treino inserido com sucesso.");
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem });
            }
        }
    }
}
