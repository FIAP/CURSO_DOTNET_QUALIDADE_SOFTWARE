using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
             options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "API de Notícias",
            Version = "v1",
            Description = "Projeto desenvolvido para demonstrar como documentar a sua API utilizando o Redoc",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact()
            {
                Name = "Thiago da Silva Adriano",
                Email = "tadriano.dev@gmail.com",
                Url = new Uri("https://programadriano.medium.com/")

            },
            Extensions = new Dictionary<string, IOpenApiExtension>
                {
                {"x-logo", new OpenApiObject
                    {
                    {"url", new OpenApiString("https://foforks.com.br/wp-content/uploads/2019/05/news.jpeg")},
                    { "altText", new OpenApiString("News")}
                    }
                }
         }


        });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseReDoc(c =>
{
  c.DocumentTitle = "REDOC API Documentation";
  c.SpecUrl = "/swagger/v1/swagger.json";

});



app.UseAuthorization();

app.MapControllers();

app.Run();
