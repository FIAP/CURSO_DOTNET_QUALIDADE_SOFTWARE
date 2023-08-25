using API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace API.Infra
{
    public interface IMongoRepository<T>
    {
        Result<T> Get(int page, int qtd);
        T Get(string id);
        T GetBySlug(string slug);
        T Create(T news);
        void Update(string id, T news);
        void Remove(string id);
    }


    public class MongoRepository<T> : IMongoRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _model;

        public MongoRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _model = database.GetCollection<T>(typeof(T).Name.ToLower());
        }
        public Result<T> Get(int page, int qtd)
        {
            var result = new Result<T>();
            result.Page = page;
            result.Qtd = qtd;
            var filter = Builders<T>.Filter.Eq(entity => entity.Deleted, false);

            result.Data = _model.Find(filter)
                .SortByDescending(entity => entity.PublishDate)
                .Skip((page - 1) * qtd).Limit(qtd).ToList();

            result.Total = _model.CountDocuments(filter);
            result.TotalPages = result.Total / qtd;

            return result;

        }

        public T Get(string id) =>
            _model.Find<T>(news => news.Id == id && news.Deleted == false).FirstOrDefault();

        public T Create(T news)
        {
            _model.InsertOne(news);
            return news;
        }

        public void Update(string id, T newsIn) => _model.ReplaceOne(news => news.Id == id, newsIn);

        public void Remove(string id)
        {
            var news = Get(id);
            news.Deleted = true;
            _model.ReplaceOne(news => news.Id == id, news);
        }

        public T GetBySlug(string slug) =>
         _model.Find<T>(news => news.Slug == slug && news.Deleted == false).FirstOrDefault();


    }
}
