public interface INewsService
{
    IList<Noticia> Get(int page, int qtd);

    Noticia Get(string id);

    Noticia Create(Noticia entity);

    void Update(string id, Noticia entity);

    void Remove(string id);
}