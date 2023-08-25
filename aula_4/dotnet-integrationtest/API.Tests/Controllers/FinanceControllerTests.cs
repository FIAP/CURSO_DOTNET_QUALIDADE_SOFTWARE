using API.Controllers;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace API.Tests
{
    public class FinanceControllerTests
    {
        private FinanceController _controller;
        private Mock<IFinanceService> _serviceMock;
        private Mock<ILogger<FinanceController>> _loggerMock;

        public FinanceControllerTests()
        {
            // Configurar o mock do serviço
            _serviceMock = new Mock<IFinanceService>();

            // Configurar o mock do logger
            _loggerMock = new Mock<ILogger<FinanceController>>();

            // Inicializar o controller com o mock do serviço e do logger
            _controller = new FinanceController(_loggerMock.Object, _serviceMock.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResultWithData()
        {
            // Arrange
            var trendingData = new List<QuoteResult>
            {
                new QuoteResult { Full_Exchange_Name = "NYSE", regular_market_change_percent = 10.869562, Symbol = "NYSE" },
              
            };

            _serviceMock.Setup(s => s.GetAllTrending()).ReturnsAsync(trendingData);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(trendingData, okResult.Value);
        }
    }
}
