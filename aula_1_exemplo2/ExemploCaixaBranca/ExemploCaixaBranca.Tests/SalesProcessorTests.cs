namespace ExemploCaixaBranca.Tests
{
    public class SalesProcessorTests
    {
        private SalesProcessor salesProcessor;

        public SalesProcessorTests()
        {
            salesProcessor = new SalesProcessor();
        }

        [Fact]
        public void TestCalculateTotalSales()
        {
            // Dados de exemplo para o teste
            List<string> itemsSold = new List<string> { "Caf�", "P�o", "Leite" };

            // C�lculo do total de vendas esperado
            double expectedTotalSales = 10.50 + 5.75 + 8.20;

            // Chama o m�todo que ser� testado
            double actualTotalSales = salesProcessor.CalculateTotalSales(itemsSold);

            // Verifica se o resultado est� correto
            Assert.Equal(expectedTotalSales, actualTotalSales, 2);
        }

        [Fact]
        public void TestCalculateTotalSales_InvalidItem()
        {
            // Dados de exemplo para o teste com um item inv�lido
            List<string> itemsSold = new List<string> { "Caf�", "P�o", "Leite","Chocolate" };

            // Testa se uma exce��o � lan�ada quando um item inv�lido � encontrado
            Assert.Throws<ArgumentException>(() => salesProcessor.CalculateTotalSales(itemsSold));
        }
    }
}