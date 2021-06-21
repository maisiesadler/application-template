using System.Threading.Tasks;
using Application.Domain;
using Application.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController : ControllerBase
    {
        private readonly ValidationInteractor _validationInteractor;
        private readonly ITrace _trace;
        private readonly ILogger<ValidationController> _logger;

        public ValidationController(
            ValidationInteractor validationInteractor,
            ITrace trace,
            ILogger<ValidationController> logger)
        {
            _validationInteractor = validationInteractor;
            _trace = trace;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int value)
        {
            await _trace.Add("beans", "ok");
            var result = await _validationInteractor.Execute(value);
            return Ok(result);
        }
    }
}
