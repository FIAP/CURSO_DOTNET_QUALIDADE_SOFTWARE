namespace ExemploCaixaBranca;

public class SalesProcessor
{
    private readonly Dictionary<string, double> priceList;

    public SalesProcessor()
    {
        // Inicializa a lista de preços dos produtos
        priceList = new Dictionary<string, double>
    {
        { "Café", 10.50 },
        { "Pão", 5.75 },
        { "Leite", 8.20 },
    };
    }

    public double CalculateTotalSales(List<string> itemsSold)
    {
        double totalSales = 0.0;

        foreach (string item in itemsSold)
        {
            if (priceList.ContainsKey(item))
            {
                totalSales += priceList[item];
            }
            else
            {
                throw new ArgumentException($"O item '{item}' não existe na lista de preços.");
            }
        }

        return totalSales;
    }
}
