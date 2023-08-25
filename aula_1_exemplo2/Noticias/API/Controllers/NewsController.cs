using Application.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("[controller]")]
public class NewsController : ControllerBase
{

    private readonly ILogger<NewsController> _logger;
    private readonly INewsUseCase _newsUseCase;

    public NewsController(ILogger<NewsController> logger, INewsUseCase newsUseCase)
    {
        _logger = logger;
        _newsUseCase = newsUseCase;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(new { data = _newsUseCase.GetAll() });
    }

}