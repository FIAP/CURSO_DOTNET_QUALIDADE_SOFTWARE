using System.Text.Json.Serialization;


public class QuoteResult
{
    [JsonPropertyName("RegularMarketChangePercent")]
    public double regular_market_change_percent { get; set; }

    [JsonPropertyName("FullExchangeName")]
    public string Full_Exchange_Name { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
}


public class Quote
{
    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("quoteType")]
    public string QuoteType { get; set; }

    [JsonPropertyName("typeDisp")]
    public string TypeDisp { get; set; }

    [JsonPropertyName("quoteSourceName")]
    public string QuoteSourceName { get; set; }

    [JsonPropertyName("triggerable")]
    public bool Triggerable { get; set; }

    [JsonPropertyName("customPriceAlertConfidence")]
    public string CustomPriceAlertConfidence { get; set; }

    [JsonPropertyName("trendingScore")]
    public double TrendingScore { get; set; }

    [JsonPropertyName("exchange")]
    public string Exchange { get; set; }

    [JsonPropertyName("market")]
    public string Market { get; set; }

    [JsonPropertyName("fullExchangeName")]
    public string FullExchangeName { get; set; }

    [JsonPropertyName("companyLogoUrl")]
    public string CompanyLogoUrl { get; set; }

    [JsonPropertyName("logoUrl")]
    public string LogoUrl { get; set; }

    [JsonPropertyName("marketState")]
    public string MarketState { get; set; }

    [JsonPropertyName("sourceInterval")]
    public int SourceInterval { get; set; }

    [JsonPropertyName("exchangeDataDelayedBy")]
    public int ExchangeDataDelayedBy { get; set; }

    [JsonPropertyName("exchangeTimezoneName")]
    public string ExchangeTimezoneName { get; set; }

    [JsonPropertyName("exchangeTimezoneShortName")]
    public string ExchangeTimezoneShortName { get; set; }

    [JsonPropertyName("gmtOffSetMilliseconds")]
    public int GmtOffSetMilliseconds { get; set; }

    [JsonPropertyName("esgPopulated")]
    public bool EsgPopulated { get; set; }

    [JsonPropertyName("tradeable")]
    public bool Tradeable { get; set; }

    [JsonPropertyName("cryptoTradeable")]
    public bool CryptoTradeable { get; set; }

    [JsonPropertyName("firstTradeDateMilliseconds")]
    public long? FirstTradeDateMilliseconds { get; set; }

    [JsonPropertyName("priceHint")]
    public int PriceHint { get; set; }

    [JsonPropertyName("regularMarketChangePercent")]
    public double RegularMarketChangePercent { get; set; }

    [JsonPropertyName("regularMarketTime")]
    public int RegularMarketTime { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
}

public class Result
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("quotes")]
    public List<Quote> Quotes { get; set; }

    [JsonPropertyName("jobTimestamp")]
    public long JobTimestamp { get; set; }

    [JsonPropertyName("startInterval")]
    public long StartInterval { get; set; }
}

public class Finance
{
    [JsonPropertyName("result")]
    public List<Result> Result { get; set; }

    [JsonPropertyName("error")]
    public object Error { get; set; }
}

public class TrendingResponse
{
    [JsonPropertyName("finance")]
    public Finance Finance { get; set; }
}
