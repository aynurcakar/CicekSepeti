FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Basket.Api/Basket.Api.csproj", "Basket.Api/"]
COPY ["Basket.Services/Basket.Services.csproj", "Basket.Services/"]
COPY ["Basket.Model/Basket.Model.csproj", "Basket.Model/"]
COPY ["Basket.Data/Basket.Data.csproj", "Basket.Data/"]
COPY ["Basket.Core/Basket.Core.csproj", "Basket.Core/"]
RUN dotnet restore "Basket.Api/Basket.Api.csproj"
COPY . .
WORKDIR "/src/Basket.Api"
RUN dotnet build "Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:8080
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 8080
ENTRYPOINT ["dotnet", "Basket.Api.dll"]