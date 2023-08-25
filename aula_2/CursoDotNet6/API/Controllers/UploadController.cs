using API.Services;
using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;
        private readonly UploadService _uploadService;

        public UploadController(ILogger<UploadController> logger, UploadService uploadService)
        {
            _logger = logger;
            _uploadService = uploadService;
        }

        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            try
            {
                //validação simples, caso não tenha sido enviado nenhuma imagem para upload nós estamos retornando null
                if (file == null) return null;

                //Salvando a imagem no formato enviado pelo usuário

                var urlFile = _uploadService.UploadFile(file);

                return Ok(new
                {
                    mensagem = "Arquivo salvo com sucesso!",
                    urlImagem = urlFile
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro no upload: " + ex.Message);
            }

        }

    }
}
