using Dapper;
using Npgsql;
using System.Text.Json;

namespace API.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly IConfiguration _configuration;

        public FinanceService()
        {
            
        }
        public FinanceService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IEnumerable<QuoteResult>> GetAllTrending()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            var result = await connection.QueryAsync<QuoteResult>("select * from quotes");

            connection.Close();

            return result.ToList();
        }

        public async Task ImporterAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://query2.finance.yahoo.com/v1/finance/trending/US?count=5&useQuotes=true&fields=logoUrl%2CregularMarketChangePercent";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var json = JsonSerializer.Deserialize<TrendingResponse>(responseBody);

                Insert(json);
            }
        }

        public void Insert(TrendingResponse finance)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                foreach (var item in finance.Finance.Result[0].Quotes.ToList())
                {

                    string insertQuery = @"
                INSERT INTO quotes (language, region, quote_type, type_disp, quote_source_name, triggerable, custom_price_alert_confidence, trending_score, exchange, market, full_exchange_name, company_logo_url, logo_url, market_state, source_interval, exchange_data_delayed_by, exchange_timezone_name, exchange_timezone_short_name, gmt_offset_milliseconds, esg_populated, tradeable, crypto_tradeable, first_trade_date_milliseconds, price_hint, regular_market_change_percent, regular_market_time, symbol)
                VALUES (@Language, @Region, @QuoteType, @TypeDisp, @QuoteSourceName, @Triggerable, @CustomPriceAlertConfidence, @TrendingScore, @Exchange, @Market, @FullExchangeName, @CompanyLogoUrl, @LogoUrl, @MarketState, @SourceInterval, @ExchangeDataDelayedBy, @ExchangeTimezoneName, @ExchangeTimezoneShortName, @GmtOffSetMilliseconds, @EsgPopulated, @Tradeable, @CryptoTradeable, @FirstTradeDateMilliseconds, @PriceHint, @RegularMarketChangePercent, @RegularMarketTime, @Symbol);";

                    connection.Execute(insertQuery, item);
                }
            }
        }
    }
}