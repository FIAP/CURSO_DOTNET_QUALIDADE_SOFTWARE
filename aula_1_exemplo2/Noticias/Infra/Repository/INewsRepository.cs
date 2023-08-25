using Domain;

namespace Infra.Repository
{
    public interface INewsRepository
    {
        IEnumerable<News> GetAll();
    }
}
