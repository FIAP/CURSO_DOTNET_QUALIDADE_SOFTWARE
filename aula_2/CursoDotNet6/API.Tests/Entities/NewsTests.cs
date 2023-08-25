using API.Entities;
using API.Entities.Enums;
using API.Tests.fixtures;
using Bogus;

namespace API.Tests.Entities
{
    [Collection(nameof(NewsTestFixtureCollection))]
    public class NewsTest
    {
        private readonly Faker _faker;
        public readonly NewsTestFixture _newsTestFixture;

        public NewsTest(NewsTestFixture newsTestFixture)
        {
            _faker = new Faker();
            _newsTestFixture = newsTestFixture;
        }

        [Fact(DisplayName = "Validando se o titulo esta vazio")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidateEntity_ShouldThrowException_WhenTitleIsEmpty()
        {
            // Arrange         


            //act
            var result = Assert.Throws<DomainException>(() => _newsTestFixture.GerarNoticiaTituloEmpty());

            //Assert
            Assert.Equal("O título não pode estar vazio!", result.Message);

        }

        [Fact(DisplayName = "Validando se o chapeu esta vazio")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidateEntity_ShouldThrowException_WhenHatIsEmpty()
        {
            // Arrange
            var hat = "";
            var title = _faker.Random.String2(40);
            var text = _faker.Random.String2(100);
            var author = _faker.Name.FullName();
            var img = _faker.Internet.Url();
            var status = Status.Active;


            //act
            var result = Assert.Throws<DomainException>(() => new News(hat, title, text, author, img, status));

            //Assert
            Assert.Equal("O chapéu não pode estar vazio!", result.Message);

        }

        [Fact(DisplayName = "Validando se o texto esta vazio")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidateEntity_ShouldThrowException_WhenTextIsEmpty()
        {
            // Arrange
            var hat = _faker.Random.String2(10);
            var title = _faker.Random.String2(50);
            var text = string.Empty;
            var author = _faker.Name.FullName();
            var img = _faker.Internet.Url();
            var status = Status.Active;

            //act
            var result = Assert.Throws<DomainException>(() => new News(hat, title, text, author, img, status));

            //Assert
            Assert.Equal("O texto não pode estar vazio!", result.Message);


        }

        [Fact(DisplayName = "Validando se a classe esta correta")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidateEntity_Should_Return_Success()
        {
            // Arrange
            var news = _newsTestFixture.GerarNoticia();           

            // Act & Assert

        }

        [Fact(DisplayName = "Validando tamanho maximo do chapeu")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidateEntity_ShouldThrowException_WhenHatHasMaxThenLength()
        {
            // Arrange
            var hat = _faker.Random.String2(41); // Generate a string longer than 40 characters
            var title = _faker.Random.String2(50);
            var text = _faker.Random.String2(100);
            var author = _faker.Name.FullName();
            var img = _faker.Internet.Url();
            var status = Status.Active;

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new News(hat, title, text, author, img, status));
            Assert.Equal("O chapéu deve ter até 40 caracteres!", exception.Message);
        }


    }
}
