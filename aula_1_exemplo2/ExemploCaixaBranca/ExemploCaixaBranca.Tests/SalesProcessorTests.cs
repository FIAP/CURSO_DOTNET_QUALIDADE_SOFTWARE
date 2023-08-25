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
            List<string> itemsSold = new List<string> { "Café", "Pão", "Leite" };

            // Cálculo do total de vendas esperado
            double expectedTotalSales = 10.50 + 5.75 + 8.20;

            // Chama o método que será testado
            double actualTotalSales = salesProcessor.CalculateTotalSales(itemsSold);

            // Verifica se o resultado está correto
            Assert.Equal(expectedTotalSales, actualTotalSales, 2);
        }

        [Fact]
        public void TestCalculateTotalSales_InvalidItem()
        {
            // Dados de exemplo para o teste com um item inválido
            List<string> itemsSold = new List<string> { "Café", "Pão", "Leite","Chocolate" };

            // Testa se uma exceção é lançada quando um item inválido é encontrado
            Assert.Throws<ArgumentException>(() => salesProcessor.CalculateTotalSales(itemsSold));
        }
    }
}