using API.Entities.ViewModels;
using API.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Tests.Services
{
    public class ClipeServiceTeste
    {
        [Fact(DisplayName = "Validando se o clipe foi criado com sucesso")]
        [Trait("Categoria", "Validando Clipe")]
        public void Create_ShouldReturnSuccessMessage()
        {
            // Arrange
            var mockClipeService = new Mock<IClipeService>();
            mockClipeService.Setup(service => service.Create(It.IsAny<ClipeViewModel>())).Returns("Clipe criado com sucesso!");

            var clipeService = mockClipeService.Object;

            // Act
            string resultado = clipeService.Create(new ClipeViewModel());

            // Assert
            Assert.Equal("Clipe criado com sucesso!", resultado);
        }
    }
}
