FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Transmutatio.Api/Transmutatio.Api.csproj", "Transmutatio.Api/"]
COPY ["Transmutatio.Ioc/Transmutatio.Ioc.csproj", "Transmutatio.Ioc/"]
COPY ["Transmutatio.Application/Transmutatio.Application.csproj", "Transmutatio.Application/"]
COPY ["Transmutatio.Domain/Transmutatio.Domain.csproj", "Transmutatio.Domain/"]
COPY ["Transmutatio.Infra/Transmutatio.Infra.csproj", "Transmutatio.Infra/"]
RUN dotnet restore "Transmutatio.Api/Transmutatio.Api.csproj"
COPY . .
WORKDIR "/src/Transmutatio.Api"
RUN dotnet build "Transmutatio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Transmutatio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transmutatio.Api.dll"]