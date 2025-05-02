namespace Transmutatio.Domain.Conversions.Services.Interfaces;

public interface IConversionsYoutubeService
{
    Task<(Stream File, string FileName, string ContentType)> ConvertToMp3(string url);
    Task<(Stream File, string FileName, string ContentType)> ConvertToMp4(string url);
}