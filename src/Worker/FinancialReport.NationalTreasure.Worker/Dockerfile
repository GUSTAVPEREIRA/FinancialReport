FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/FinancialReport.NationalTreasure.Worker/FinancialReport.NationalTreasure.Worker.csproj", "src/FinancialReport.NationalTreasure.Worker/"]
RUN dotnet restore "src/FinancialReport.NationalTreasure.Worker/FinancialReport.NationalTreasure.Worker.csproj"
COPY . .
WORKDIR "/src/src/FinancialReport.NationalTreasure.Worker"
RUN dotnet build "FinancialReport.NationalTreasure.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FinancialReport.NationalTreasure.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinancialReport.NationalTreasure.Worker.dll"]
