using Transmutatio.Domain.Conversions.Enums;

namespace Transmutatio.Domain.Youtube.Services.Interfaces;

public interface IYoutubeService
{
    /// <summary>
    /// Gerencia o download e o muxing do YouTube através do yt-dlp.
    /// </summary>
    /// <returns>O caminho do arquivo físico gerado no diretório temporário.</returns>
    Task<string> DownloadFromUrlAsync(string url, TargetFormat format);
}