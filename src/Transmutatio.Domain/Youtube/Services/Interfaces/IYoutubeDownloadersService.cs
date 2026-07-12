using Transmutatio.Domain.Conversions.Enums;

namespace Transmutatio.Domain.Youtube.Services.Interfaces;

public interface IYoutubeDownloadersService
{
    /// <summary>
    /// Realiza o download e a conversão da mídia usando as ferramentas do sistema operacional.
    /// </summary>
    /// <returns>O caminho absoluto do arquivo final gerado no servidor (/tmp/...).</returns>
    Task<string> DownloadMediaAsync(string videoUrl, TargetFormat targetFormat, string outputDirectory);
}