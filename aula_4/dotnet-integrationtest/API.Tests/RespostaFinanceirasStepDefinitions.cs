using System;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace API.Tests
{
    [Binding]
    public class TesteStepDefinitions
    {
        private string jsonResponse;
        private TrendingResponse trendingResponse;

        [Given(@"que eu tenha uma resposta JSON com dados de cotações financeiras")]
        public void GivenQueEuTenhaUmaRespostaJSONComDadosDeCotacoesFinanceiras()
        {
            jsonResponse = "{\"finance\":{\"result\":[{\"count\":5,\"quotes\":[{\"language\":\"en-US\",\"region\":\"US\",\"quoteType\":\"CRYPTOCURRENCY\",\"typeDisp\":\"Cryptocurrency\",\"quoteSourceName\":\"CoinMarketCap\",\"triggerable\":false,\"customPriceAlertConfidence\":\"LOW\",\"trendingScore\":23.483479090965638,\"firstTradeDateMilliseconds\":1410912000000,\"sourceInterval\":15,\"exchangeDataDelayedBy\":0,\"exchangeTimezoneName\":\"UTC\",\"exchangeTimezoneShortName\":\"UTC\",\"gmtOffSetMilliseconds\":0,\"esgPopulated\":false,\"tradeable\":false,\"cryptoTradeable\":true,\"regularMarketChangePercent\":-0.38085774,\"regularMarketTime\":1690077960,\"exchange\":\"CCC\",\"market\":\"ccc_market\",\"fullExchangeName\":\"CCC\",\"coinImageUrl\":\"https://s2.coinmarketcap.com/static/img/coins/64x64/1.png\",\"logoUrl\":\"https://s2.coinmarketcap.com/static/img/coins/64x64/1.png\",\"marketState\":\"REGULAR\",\"symbol\":\"BTC-USD\"},{\"language\":\"en-US\",\"region\":\"US\",\"quoteType\":\"EQUITY\",\"typeDisp\":\"Equity\",\"quoteSourceName\":\"Delayed Quote\",\"triggerable\":false,\"customPriceAlertConfidence\":\"LOW\",\"trendingScore\":14.989040470858408,\"firstTradeDateMilliseconds\":1466688600000,\"priceHint\":2,\"sourceInterval\":15,\"exchangeDataDelayedBy\":0,\"exchangeTimezoneName\":\"America/New_York\",\"exchangeTimezoneShortName\":\"EDT\",\"gmtOffSetMilliseconds\":-14400000,\"esgPopulated\":false,\"tradeable\":false,\"cryptoTradeable\":false,\"regularMarketChangePercent\":-0.9072155,\"regularMarketTime\":1689969602,\"exchange\":\"NYQ\",\"market\":\"us_market\",\"fullExchangeName\":\"NYSE\",\"companyLogoUrl\":\"https://s.yimg.com/lb/brands/150x150_twilio.png\",\"logoUrl\":\"https://s.yimg.com/lb/brands/150x150_twilio.png\",\"marketState\":\"CLOSED\",\"symbol\":\"TWLO\"},{\"language\":\"en-US\",\"region\":\"US\",\"quoteType\":\"CRYPTOCURRENCY\",\"typeDisp\":\"Cryptocurrency\",\"quoteSourceName\":\"CoinMarketCap\",\"triggerable\":false,\"customPriceAlertConfidence\":\"LOW\",\"trendingScore\":14.331059898615958,\"firstTradeDateMilliseconds\":1510185600000,\"sourceInterval\":15,\"exchangeDataDelayedBy\":0,\"exchangeTimezoneName\":\"UTC\",\"exchangeTimezoneShortName\":\"UTC\",\"gmtOffSetMilliseconds\":0,\"esgPopulated\":false,\"tradeable\":false,\"cryptoTradeable\":false,\"regularMarketChangePercent\":-4.949273,\"regularMarketTime\":1690077960,\"exchange\":\"CCC\",\"market\":\"ccc_market\",\"fullExchangeName\":\"CCC\",\"coinImageUrl\":\"https://s2.coinmarketcap.com/static/img/coins/64x64/52.png\",\"logoUrl\":\"https://s2.coinmarketcap.com/static/img/coins/64x64/52.png\",\"marketState\":\"REGULAR\",\"symbol\":\"XRP-USD\"},{\"language\":\"en-US\",\"region\":\"US\",\"quoteType\":\"CRYPTOCURRENCY\",\"typeDisp\":\"Cryptocurrency\",\"quoteSourceName\":\"CoinMarketCap\",\"triggerable\":false,\"customPriceAlertConfidence\":\"LOW\",\"trendingScore\":12.037130305061346,\"firstTradeDateMilliseconds\":1510185600000,\"sourceInterval\":15,\"exchangeDataDelayedBy\":0,\"exchangeTimezoneName\":\"UTC\",\"exchangeTimezoneShortName\":\"UTC\",\"gmtOffSetMilliseconds\":0,\"esgPopulated\":false,\"tradeable\":false,\"cryptoTradeable\":true,\"regularMarketChangePercent\":-1.25624,\"regularMarketTime\":1690077960,\"exchange\":\"CCC\",\"market\":\"ccc_market\",\"fullExchangeName\":\"CCC\",\"coinImageUrl\":\"https://s2.coinmarketcap.com/static/img/coins/64x64/1027.png\",\"logoUrl\":\"https://s2.coinmarketcap.com/static/img/coins/64x64/1027.png\",\"marketState\":\"REGULAR\",\"symbol\":\"ETH-USD\"},{\"language\":\"en-US\",\"region\":\"US\",\"quoteType\":\"EQUITY\",\"typeDisp\":\"Equity\",\"quoteSourceName\":\"Delayed Quote\",\"triggerable\":false,\"customPriceAlertConfidence\":\"LOW\",\"trendingScore\":9.612132292148111,\"firstTradeDateMilliseconds\":1246455000000,\"priceHint\":2,\"sourceInterval\":15,\"exchangeDataDelayedBy\":0,\"exchangeTimezoneName\":\"America/New_York\",\"exchangeTimezoneShortName\":\"EDT\",\"gmtOffSetMilliseconds\":-14400000,\"esgPopulated\":false,\"tradeable\":false,\"cryptoTradeable\":false,\"regularMarketChangePercent\":-0.30648783,\"regularMarketTime\":1689969602,\"exchange\":\"NYQ\",\"market\":\"us_market\",\"fullExchangeName\":\"NYSE\",\"marketState\":\"CLOSED\",\"symbol\":\"BUD\"}],\"jobTimestamp\":1690074367928,\"startInterval\":202307230000}],\"error\":null}}";
        }

        [When(@"eu desserializar a resposta para um objeto TrendingResponse")]
        public void WhenEuDesserializarARespostaParaUmObjetoTrendingResponse()
        {
            trendingResponse = JsonSerializer.Deserialize<TrendingResponse>(jsonResponse);
        }


        [Then(@"a propriedade count do objeto Result deve ser maior que (.*)")]
        public void ThenAPropriedadeCountDoObjetoResultDeveSerMaiorQue(int valorEsperado)
        {
            Assert.NotNull(trendingResponse);
            Assert.NotNull(trendingResponse.Finance);
            Assert.NotNull(trendingResponse.Finance.Result);

            // Verifica se a propriedade "count" do primeiro objeto Result é maior que o valor esperado
            int count = trendingResponse.Finance.Result.FirstOrDefault()?.Count ?? 0;
            Assert.True(count > valorEsperado, $"Esperado: {valorEsperado}, Obtido: {count}");
        }
    }
}
