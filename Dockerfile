# =========================================================
# 1. Imagem Base de Runtime com as dependências do OS
# =========================================================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# Mudar temporariamente para root para instalar os pacotes do Linux
USER root

# Instalar ffmpeg, python3 (requerido pelo yt-dlp) e curl para baixar o yt-dlp atualizado
RUN apt-get update && apt-get install -y \
    ffmpeg \
    python3 \
    curl \
    && rm -rf /var/lib/apt/lists/*

# Baixar a versão estável mais recente do yt-dlp diretamente do repositório oficial
RUN curl -L https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp -o /usr/local/bin/yt-dlp \
    && chmod a+rx /usr/local/bin/yt-dlp

# Voltar para o usuário do .NET por segurança, mas garantir acesso à pasta /app
RUN chown -R 1654:1654 /app
USER 1654

# =========================================================
# 2. Imagem de Build
# =========================================================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Note o "src/" adicionado APENAS no primeiro argumento de cada linha (a origem na sua máquina)
COPY ["src/Transmutatio.Api/Transmutatio.Api.csproj", "Transmutatio.Api/"]
COPY ["src/Transmutatio.Ioc/Transmutatio.Ioc.csproj", "Transmutatio.Ioc/"]
COPY ["src/Transmutatio.Application/Transmutatio.Application.csproj", "Transmutatio.Application/"]
COPY ["src/Transmutatio.Domain/Transmutatio.Domain.csproj", "Transmutatio.Domain/"]
COPY ["src/Transmutatio.Infra/Transmutatio.Infra.csproj", "Transmutatio.Infra/"]

# O segundo argumento continua igual porque dentro do contêiner ele vai achatar a estrutura
RUN dotnet restore "Transmutatio.Api/Transmutatio.Api.csproj"

COPY src/ .
WORKDIR "/src/Transmutatio.Api"
RUN dotnet build "Transmutatio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# =========================================================
# 3. Etapa de Publicação
# =========================================================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Transmutatio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# =========================================================
# 4. Construção da Imagem Final
# =========================================================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transmutatio.Api.dll"]