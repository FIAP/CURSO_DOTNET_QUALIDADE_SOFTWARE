using Domain;

namespace Infra.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly string _connectionString = "";

        private readonly IList<News> _news = new List<News>
        {
            new News("Brasil Urgente","Brasil urgente aqui","djldkjslkdjskldjkl","",""),
            new News("Brasil Urgente 2","Brasil urgente aqui","djldkjslkdjskldjkl","","")
        };
        public IEnumerable<News> GetAll()
        {
            //retornando dados via Dapper
            return _news.ToList();
        }
    }
}
