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
    public class GalleryController : ControllerBase
    {

        private readonly ILogger<GalleryController> _logger;
        private readonly GalleryService _galleryService;

        public GalleryController(ILogger<GalleryController> logger, GalleryService galleryService)
        {
            _logger = logger;
            _galleryService = galleryService;
        }

        [HttpGet("{page}/{qtd}")]
        public ActionResult<Result<GalleryViewModel>> Get(int page, int qtd) => _galleryService.Get(page, qtd);

        [HttpGet("{id:length(24)}", Name = "GetGallery")]
        public ActionResult<GalleryViewModel> Get(string id)
        {
            var news = _galleryService.Get(id);

            if (news is null)
                return NotFound();

            return news;
        }

        [HttpPost]
        public ActionResult<GalleryViewModel> Create(GalleryViewModel news)
        {
            var result = _galleryService.Create(news);

            return CreatedAtRoute("GetGallery", new { id = result.Id.ToString() }, result);
        }


        [HttpPut("{id:length(24)}")]
        public ActionResult<GalleryViewModel> Update(string id, GalleryViewModel galleryIn)
        {
            var gallery = _galleryService.Get(id);

            if (gallery is null)
                return NotFound();


            galleryIn.PublishDate = gallery.PublishDate;


            _galleryService.Update(id, galleryIn);

            return CreatedAtRoute("GetGallery", new { id = id }, galleryIn);

        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var gallery = _galleryService.Get(id);

            if (gallery is null)
                return NotFound();

            _galleryService.Remove(gallery.Id);

            var result = new
            {
                message = "Galeria deletada com sucesso!"
            };

            return Ok(result);
        }

    }
}
