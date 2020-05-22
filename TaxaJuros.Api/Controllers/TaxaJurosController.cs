using Microsoft.AspNetCore.Mvc;
using TaxaJuros.Api.Infrastructure;

namespace TaxaJuros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly IJurosService _jurosService;

        public TaxaJurosController(IJurosService jurosService)
        {
            _jurosService = jurosService;
        }

        [HttpGet]
        public ObjectResult Get()
        {
            return Ok(_jurosService.getJuros());
        }
    }
}
