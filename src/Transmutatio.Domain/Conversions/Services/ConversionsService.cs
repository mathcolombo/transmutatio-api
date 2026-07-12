using Transmutatio.Domain.Conversions.Commands;
using Transmutatio.Domain.Conversions.Enums;
using Transmutatio.Domain.Conversions.Services.Interfaces;
using Transmutatio.Domain.Youtube.Services.Interfaces;

namespace Transmutatio.Domain.Conversions.Services;

public class ConversionsService(IYoutubeService youtubeService) : IConversionsService
{
    public async Task<ConversionYoutubeResultCommand> ExecuteYoutubeConversionAsync(string url, TargetFormat format)
    {
        string localFilePath = await youtubeService.DownloadFromUrlAsync(url, format);
        
        if (!File.Exists(localFilePath))
            throw new FileNotFoundException();
        
        byte[] fileBytes = await File.ReadAllBytesAsync(localFilePath);

        File.Delete(localFilePath);

        string contentType = format == TargetFormat.Mp3 ? "audio/mpeg" : "video/mp4";
        string downloadName = format == TargetFormat.Mp3 ? "audio.mp3" : "video.mp4";

        return new ConversionYoutubeResultCommand
        { 
            FileBytes = fileBytes,
            ContentType = contentType,
            DownloadName = downloadName
        };
    }
}