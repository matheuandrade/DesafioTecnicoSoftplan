using CalculaJuros.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculaJuros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosService _calculaJurosService;
        public CalculaJurosController(ICalculaJurosService calculaJurosService)
        {
            _calculaJurosService = calculaJurosService;
        }

        [HttpGet]
        public async Task<ObjectResult> Get([FromQuery] decimal valorInicial, [FromQuery] int tempo)
        {
            return Ok(await _calculaJurosService.calculaJuros(valorInicial, tempo));
        }
    }
}
