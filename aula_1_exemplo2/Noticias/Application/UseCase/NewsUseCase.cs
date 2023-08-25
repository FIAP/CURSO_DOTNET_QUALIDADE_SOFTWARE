using Domain;
using Infra.Repository;

namespace Application.UseCase
{
    public class NewsUseCase : INewsUseCase
    {
        private  INewsRepository _newsRepository;

        public NewsUseCase(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        public IEnumerable<News> GetAll()
        {
            return _newsRepository.GetAll();
        }
    }
}
