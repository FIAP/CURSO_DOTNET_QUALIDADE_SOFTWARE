using API.Entities.Enums;
using API.Entities;
using Bogus;

namespace API.Tests.fixtures
{

    public class NewsTestFixture 
    {
        private readonly Faker _faker;

        public NewsTestFixture()
        {
            _faker = new Faker();
        }

        public News GerarNoticiaTituloEmpty()
        {
            // Arrange
            var hat = _faker.Random.String2(10);
            var title = string.Empty;
            var text = _faker.Random.String2(100);
            var author = _faker.Name.FullName();
            var img = _faker.Internet.Url();
            var status = Status.Active;

            return new News(hat, title, text, author, img, status);
        }

        public News GerarNoticia()
        {
            // Arrange
            var hat = _faker.Random.String2(10);
            var title = _faker.Random.String2(40);
            var text = _faker.Random.String2(100);
            var author = _faker.Name.FullName();
            var img = _faker.Internet.Url();
            var status = Status.Active;

            return new News(hat, title, text, author, img, status);
        }

      
    }
}
