using Transmutatio.Domain.Conversions.Enums;
using Transmutatio.Domain.Youtube.Services.Interfaces;

namespace Transmutatio.Domain.Youtube.Services;

public class YoutubeService(
    IYoutubeDownloadersService youtubeDownloadersService    
) : IYoutubeService
{
    public async Task<string> DownloadFromUrlAsync(string url, TargetFormat format)
    {
        string baseTempPath = Path.GetTempPath();
        string targetDirectory = Path.Combine(baseTempPath, "TransmutatioMedia");
        
        return await youtubeDownloadersService.DownloadMediaAsync(url, format, targetDirectory);
    }
}