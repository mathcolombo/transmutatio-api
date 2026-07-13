using Transmutatio.Domain.Conversions.Enums;
using Transmutatio.Domain.Youtube.Services.Interfaces;

namespace Transmutatio.Domain.Youtube.Services;

public class YoutubeService(
    IYoutubeDownloadersService youtubeDownloadersService    
) : IYoutubeService
{
    public async Task<string> DownloadFromUrlAsync(string url, TargetFormat format)
    {
        string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        string subFolder = format == TargetFormat.Mp3 ? "Music" : "Videos";
        string path = Path.Combine(homePath, subFolder);
        
        return await youtubeDownloadersService.DownloadMediaAsync(url, format, path);
    }
}