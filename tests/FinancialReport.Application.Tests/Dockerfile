FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["tests/FinancialReport.Application.Tests/FinancialReport.Application.Tests.csproj", "tests/FinancialReport.Application.Tests/"]
RUN dotnet restore "tests/FinancialReport.Application.Tests/FinancialReport.Application.Tests.csproj"
COPY . .
WORKDIR "/src/tests/FinancialReport.Application.Tests"
RUN dotnet build "FinancialReport.Application.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FinancialReport.Application.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinancialReport.Application.Tests.dll"]
