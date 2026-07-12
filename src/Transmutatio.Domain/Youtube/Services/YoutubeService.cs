using Transmutatio.Domain.Conversions.Enums;
using Transmutatio.Domain.Youtube.Services.Interfaces;

namespace Transmutatio.Domain.Youtube.Services;

public class YoutubeService(
    IYoutubeDownloadersService youtubeDownloadersService    
) : IYoutubeService
{
    public async Task<string> DownloadFromUrlAsync(string url, TargetFormat format)
    {
        // Captura o caminho absoluto da Home do usuário no Linux (Ex: /home/seu-usuario)
        string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        // Combina o caminho de forma correta e nativa para o Linux
        string subFolder = format == TargetFormat.Mp3 ? "Music" : "Videos";
        string path = Path.Combine(homePath, subFolder);
        
        return await youtubeDownloadersService.DownloadMediaAsync(url, format, path);
    }
}