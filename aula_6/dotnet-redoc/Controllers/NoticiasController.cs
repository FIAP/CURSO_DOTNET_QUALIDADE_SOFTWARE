using Microsoft.AspNetCore.Mvc;

namespace dotnet_redoc.Controllers;

[ApiController]
[Route("[controller]")]
public class NoticiasController : ControllerBase
{

    private readonly INewsService _newsService;

    private readonly ILogger<NoticiasController> _logger;

    public NoticiasController(ILogger<NoticiasController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Busca paginada
    /// </summary>
    /// <param name="page">pagina</param>
    /// <param name="qtd">quantidade</param>
    /// <returns></returns>
    [HttpGet("{page}/{qtd}")]
    public IActionResult Get(int page, int qtd)
    {
        return Ok(_newsService.Get(page, qtd));
    }


    /// <summary>
    /// Buscar notícia por referencia
    /// </summary>
    /// <param name="id">Id da notícia</param>
    /// <returns></returns>
    [HttpGet("{id}", Name = "GetNews")]
    public ActionResult<Noticia> Get(string id)
    {
        var news = _newsService.Get(id);

        if (news is null)
            return NotFound();

        return news;
    }

    /// <summary>
    /// Criar notícia
    /// </summary>
    /// <param name="news">Objeto</param>
    /// <returns></returns>
    [HttpPost(Name = "Create")]
    public ActionResult<Noticia> Create(Noticia news)
    {
        var result = _newsService.Create(news);

        return CreatedAtRoute("GetNews", new { id = result.Id.ToString() }, result);
    }


    /// <summary>
    /// Atualizar notícia
    /// </summary>
    /// <param name="id">Id da notícia</param>
    /// <param name="newsIn">Objeto</param>
    /// <returns></returns>
    [HttpPut("{id}", Name = "Update")]
    public ActionResult<Noticia> Update(string id, Noticia newsIn)
    {
        var news = _newsService.Get(id);

        if (news is null)
            return NotFound();

        _newsService.Update(id, newsIn);

        return CreatedAtRoute("GetNews", new { id = id }, newsIn);

    }

    /// <summary>
    /// Deletar notícia
    /// </summary>
    /// <param name="id">Id da notícia</param>
    /// <returns></returns>
    [HttpDelete("{id}", Name = "Delete")]
    public IActionResult Delete(string id)
    {
        var news = _newsService.Get(id);

        if (news is null)
            return NotFound();

        _newsService.Remove(news.Id);

        var result = new
        {
            message = "Notícia deletada com sucesso!"
        };

        return Ok(result);
    }


}
