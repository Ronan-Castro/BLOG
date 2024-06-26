# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0. as build
WORKDIR /source
COPY . .
RUN dotnet restore "./BlogAPI.csproj" --disable-parallel
RUN dotnet publish "./BlogAPI.csproj" -c release -o /app --no-restore

# Etapa de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "BlogAPI.dll"]
