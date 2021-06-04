using System.Threading.Tasks;
using Application.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController : ControllerBase
    {
        private readonly ValidationInteractor _validationInteractor;
        private readonly ILogger<ValidationController> _logger;

        public ValidationController(
            ValidationInteractor validationInteractor,
            ILogger<ValidationController> logger)
        {
            _validationInteractor = validationInteractor;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int value)
        {
            var result = await _validationInteractor.Execute(value);
            return Ok(result);
        }
    }
}
