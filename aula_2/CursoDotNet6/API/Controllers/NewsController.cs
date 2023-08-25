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
    public class NewsController : ControllerBase
    {

        private readonly ILogger<NewsController> _logger;
        private readonly NewsService _newsService;

        public NewsController(ILogger<NewsController> logger, NewsService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        [HttpGet("{page}/{qtd}")]
        public ActionResult<Result<NewsViewModel>> Get(int page, int qtd) => _newsService.Get(page, qtd);

        [HttpGet("{id:length(24)}", Name = "GetNews")]
        public ActionResult<NewsViewModel> Get(string id)
        {
            var news = _newsService.Get(id);

            if (news is null)
                return NotFound();

            return news;
        }

        [HttpPost]
        public ActionResult<NewsViewModel> Create(NewsViewModel news)
        {
            var result = _newsService.Create(news);

            return CreatedAtRoute("GetNews", new { id = result.Id.ToString() }, result);
        }


        [HttpPut("{id:length(24)}")]
        public ActionResult<NewsViewModel> Update(string id, NewsViewModel newsIn)
        {
            var news = _newsService.Get(id);

            if (news is null)
                return NotFound();

            newsIn.PublishDate = news.PublishDate;

            _newsService.Update(id, newsIn);

            return CreatedAtRoute("GetNews", new { id = id }, newsIn);

        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var news = _newsService.Get(id);

            if (news is null)
                return NotFound();

            _newsService.Remove(news.Id);

            var result = new
            {
                message = "Noticia deletada com sucesso!"
            };

            return Ok(result);
        }

    }
}
