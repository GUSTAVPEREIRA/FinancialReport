FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/FinancialReport.RealEstateInvestmentTrust.Worker/FinancialReport.RealEstateInvestmentTrust.Worker.csproj", "src/FinancialReport.RealEstateInvestmentTrust.Worker/"]
RUN dotnet restore "src/FinancialReport.RealEstateInvestmentTrust.Worker/FinancialReport.RealEstateInvestmentTrust.Worker.csproj"
COPY . .
WORKDIR "/src/src/FinancialReport.RealEstateInvestmentTrust.Worker"
RUN dotnet build "FinancialReport.RealEstateInvestmentTrust.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FinancialReport.RealEstateInvestmentTrust.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinancialReport.RealEstateInvestmentTrust.Worker.dll"]
