# Estágio de compilação
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar todos os arquivos do projeto
COPY ./API .

# Compilar e publicar o aplicativo
RUN dotnet publish -c Release -o /app/publish

# Estágio de tempo de execução
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Executar o aplicativo
ENTRYPOINT ["dotnet", "API.dll"]
