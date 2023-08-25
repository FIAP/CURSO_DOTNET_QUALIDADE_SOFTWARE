using API.Entities;
using API.Entities.ViewModels;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoExternalController : ControllerBase
    {

        private readonly ILogger<VideoExternalController> _logger;
        private readonly VideoService _videoService;

        public VideoExternalController(ILogger<VideoExternalController> logger, VideoService newsService)
        {
            _logger = logger;
            _videoService = newsService;
        }

        [HttpGet("{page}/{qtd}")]
        public ActionResult<Result<VideoViewModel>> Get(int page, int qtd) => _videoService.Get(page, qtd);


        [HttpGet("{slug}")]
        public ActionResult<VideoViewModel> Get(string slug)
        {
            var news = _videoService.GetBySlug(slug);

            if (news is null)
                return NotFound();

            return news;
        }


    }
}
