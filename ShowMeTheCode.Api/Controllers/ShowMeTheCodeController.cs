using Microsoft.AspNetCore.Mvc;
using System;

namespace ShowMeTheCode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        [HttpGet]
        public ObjectResult Get()
        {
            return Ok(new Uri("https://github.com/matheuandrade/DesafioTecnicoSoftplan"));
        }
    }
}
