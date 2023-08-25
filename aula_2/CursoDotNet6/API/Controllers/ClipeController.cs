using API.Entities;
using API.Entities.ViewModels;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

#if !DEBUG
    [Authorize]
#endif
    [ApiController]
    [Route("[controller]")]
    public class ClipeController : ControllerBase
    {

        private readonly ILogger<ClipeController> _logger;
        private readonly IClipeService _clipeService;

        public ClipeController(ILogger<ClipeController> logger, IClipeService clipeService)
        {
            _logger = logger;
            _clipeService = clipeService;
        }

        public IClipeService Get_clipeService()
        {
            return _clipeService;
        }

        [HttpPost]
        public IActionResult Create(ClipeViewModel clipe)
        {
            var result = _clipeService.Create(clipe);

            return Ok(result);

        }




    }
}
