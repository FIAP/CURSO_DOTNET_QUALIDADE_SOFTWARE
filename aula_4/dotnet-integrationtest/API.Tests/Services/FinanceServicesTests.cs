using API.Services;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace API.Tests;

public class FinanceServicesTests : IClassFixture<DockerFixture>
{
    private readonly DockerFixture _dockerFixture;

    public FinanceServicesTests(DockerFixture dockerFixture)
    {
        _dockerFixture = dockerFixture;

        using (var connection = new NpgsqlConnection(_dockerFixture.GetConnectionString()))
        {
           

            string createTableQuery = @"
                CREATE TABLE quotes (
                      id SERIAL PRIMARY KEY,
                      language VARCHAR(255),
                      region VARCHAR(255),
                      quote_type VARCHAR(255),
                      type_disp VARCHAR(255),
                      quote_source_name VARCHAR(255),
                      triggerable BOOLEAN,
                      custom_price_alert_confidence VARCHAR(255),
                      trending_score DOUBLE PRECISION,
                      exchange VARCHAR(255),
                      market VARCHAR(255),
                      full_exchange_name VARCHAR(255),
                      company_logo_url VARCHAR(255),
                      logo_url VARCHAR(255),
                      market_state VARCHAR(255),
                      source_interval INT,
                      exchange_data_delayed_by INT,
                      exchange_timezone_name VARCHAR(255),
                      exchange_timezone_short_name VARCHAR(255),
                      gmt_offset_milliseconds INT,
                      esg_populated BOOLEAN,
                      tradeable BOOLEAN,
                      crypto_tradeable BOOLEAN,
                      first_trade_date_milliseconds BIGINT,
                      price_hint INT,
                      regular_market_change_percent DOUBLE PRECISION,
                      regular_market_time INT,
                      symbol VARCHAR(255)
                    );
                ";
            connection.Execute(createTableQuery);
        }
    }



    [Fact]
    public async void Should_Insert_Fi_With_Success()
    {
        var _connectionString = _dockerFixture.GetConnectionString();

        var configValues = new Dictionary<string, string>
{
    { "ConnectionStrings:DefaultConnection", _connectionString }
};

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configValues)
            .Build();


        var insertFeed = new FinanceService(configuration);
        await insertFeed.ImporterAsync();

    }

}
