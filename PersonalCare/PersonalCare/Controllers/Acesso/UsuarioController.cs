using Microsoft.AspNetCore.Mvc;

namespace PersonalCare.API.Controllers.Acesso
{
    [ApiController]
    [Route("acesso/[controller]")]
    [ApiExplorerSettings(GroupName = "acesso")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
