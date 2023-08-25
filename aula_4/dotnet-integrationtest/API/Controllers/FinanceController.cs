using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceController : ControllerBase
    {

        private readonly IFinanceService _service;
        private readonly ILogger<FinanceController> _logger;

        public FinanceController(ILogger<FinanceController> logger, IFinanceService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllTrending());
        }
    }
}