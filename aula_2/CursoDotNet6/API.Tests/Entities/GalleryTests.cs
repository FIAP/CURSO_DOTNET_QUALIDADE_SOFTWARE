using API.Entities;

namespace API.Tests.Entities
{
    public class GalleryTests
    {
        public IList<string> GalleryImages { get; set; }
        public GalleryTests()
        {
            GalleryImages = new List<string>();
            GalleryImages.Add("http://localhost:5005/imgs/f168c0e0-790a-4247-934e-1f9d32bf4a5e.webp");

        }

        [Fact(DisplayName = "Validando o tamanho do titulo")]
        [Trait("Categoria", "Validando Galeria")]
        public void News_Validate_Title_Lenght()
        {
            //Arrange & Act
            var result = Assert.Throws<DomainException>(() => new Gallery(
                 "A Band preparou uma série de atrações para agitar o fim de ano. Nesta terça-feira (21), às 22h30, o público acompanha o MasterChef Especial de Natal com a presença de vários famosos. Na primeira prova, Adriana Birolli e Toni Garrido enfrentam Negra Li e Felipe Titto. A dupla que fizer o melhor hambúrguer com acompanhamento e molho vence a disputa.\n\nNo segundo desafio, as gêmeas nadadoras Bia e Branca Feres encaram os gêmeos lutadores Rodrigo Minotauro e Rogério Minotouro. Os irmãos terão de preparar receitas natalinas de família.\n\n",
                 "Legenda",
                 "Da Redação",
                 "teste;azul",
                 status: API.Entities.Enums.Status.Active,
                 GalleryImages, ""));

            //Assert
            Assert.Equal("O título deve ter até 90 caracteres!", result.Message);
        }


        [Fact(DisplayName = "Validando o tamanho da legenda")]
        [Trait("Categoria", "Validando Galeria")]
        public void News_Validate_Legend_Lenght()
        {
            //Arrange & Act
            var result = Assert.Throws<DomainException>(() => new Gallery(
                 "Title",
                 "A Band preparou uma série de atrações para agitar o fim de ano. Nesta terça-feira (21), às 22h30, o público acompanha o MasterChef Especial de Natal com a presença de vários famosos. Na primeira prova, Adriana Birolli e Toni Garrido enfrentam Negra Li e Felipe Titto. A dupla que fizer o melhor hambúrguer com acompanhamento e molho vence a disputa.\n\nNo segundo desafio, as gêmeas nadadoras Bia e Branca Feres encaram os gêmeos lutadores Rodrigo Minotauro e Rogério Minotouro. Os irmãos terão de preparar receitas natalinas de família.\n\n",
                 "Da Redação",
                 "teste;azul",
                 status: API.Entities.Enums.Status.Active,
                 GalleryImages, ""));

            //Assert
            Assert.Equal("A legenda deve ter até 40 caracteres!", result.Message);
        }


        [Fact(DisplayName = "Validando se o titulo esta vazia")]
        [Trait("Categoria", "Validando Galeria")]
        public void News_Validate_Title_Empty()
        {
            //Arrange & Act
            var result = Assert.Throws<DomainException>(() => new Gallery(
                 string.Empty,
                "A Band preparou uma série de atrações para agitar o fim de ano. Nesta terça-feira (21), às 22h30, o público acompanha o MasterChef Especial de Natal com a presença de vários famosos. Na primeira prova, Adriana Birolli e Toni Garrido enfrentam Negra Li e Felipe Titto. A dupla que fizer o melhor hambúrguer com acompanhamento e molho vence a disputa.\n\nNo segundo desafio, as gêmeas nadadoras Bia e Branca Feres encaram os gêmeos lutadores Rodrigo Minotauro e Rogério Minotouro. Os irmãos terão de preparar receitas natalinas de família.\n\n",
                "Da Redação",
                "teste;azul",
                status: API.Entities.Enums.Status.Active,
                GalleryImages, ""));

            //Assert
            Assert.Equal("O título não pode estar vazio!", result.Message);
        }


        [Fact(DisplayName = "Validando se a legenda esta vazia")]
        [Trait("Categoria", "Validando Galeria")]
        public void News_Validate_Legend_Empty()
        {
            //Arrange & Act
            var result = Assert.Throws<DomainException>(() => new Gallery(
                "Entretenimento",
                 string.Empty,
                "Da Redação",
                "teste;azul",
                status: API.Entities.Enums.Status.Active,
                GalleryImages, ""));

            //Assert
            Assert.Equal("A legenda não pode estar vazia!", result.Message);
        }

    }
}
