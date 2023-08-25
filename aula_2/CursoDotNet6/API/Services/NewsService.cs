using API.Entities;
using API.Entities.ViewModels;
using API.Infra;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class NewsService
    {
        private readonly IMapper _mapper;

        private readonly IMongoRepository<News> _news;

        public NewsService(IMongoRepository<News> news, IMapper mapper)
        {
            _mapper = mapper;
            _news = news;
        }

        public Result<NewsViewModel> Get(int page, int qtd) =>
            _mapper.Map<Result<NewsViewModel>>(_news.Get(page, qtd));


        public NewsViewModel Get(string id) =>
           _mapper.Map<NewsViewModel>(_news.Get(id));

        public NewsViewModel GetBySlug(string slug) =>
       _mapper.Map<NewsViewModel>(_news.GetBySlug(slug));


        public NewsViewModel Create(NewsViewModel news)
        {
            var entity = new News(news.Hat, news.Title, news.Text, news.Author, news.Img, news.Status);
            entity.PublishDate = DateTime.Now;

            _news.Create(entity);

            return Get(entity.Id);
        }

        public void Update(string id, NewsViewModel newsIn)
        {
            _news.Update(id, _mapper.Map<News>(newsIn));
        }

        public void Remove(string id) => _news.Remove(id);

    }
}
