using Microsoft.AspNetCore.Mvc;
using PersonalCare.Application.Interfaces;
using PersonalCare.Application.Models.Requests.Conta;
using PersonalCare.Shared;

namespace PersonalCare.API.Controllers.Conta
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IConta _conta;

        public ContaController(IConta conta)
        {
            _conta = conta;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lista = _conta.Listar();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Inserir(ContaRequest request)
        {
            try
            {
                var conta = _conta.Inserir(request);
                return StatusCode(200, conta);
            }
            catch (PersonalCareException ex)
            {
                return StatusCode((int)ex.StatusCode, new { ex.Erro, ex.Mensagem } );
            }
        }
    }
}
