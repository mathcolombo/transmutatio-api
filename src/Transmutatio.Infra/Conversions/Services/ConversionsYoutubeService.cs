using System.Runtime.InteropServices.ComTypes;
using Transmutatio.Domain.Conversions.Services.Interfaces;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Transmutatio.Infra.Conversions.Services;

public class ConversionsYoutubeService : IConversionsYoutubeService
{
    private readonly YoutubeClient _youtubeClient;

    public ConversionsYoutubeService()
    {
        _youtubeClient = new YoutubeClient();
    }

    public async Task<(Stream File, string FileName, string ContentType)> ConvertToMp3(string url)
    {
        var video = await _youtubeClient.Videos.GetAsync(url);
        
        var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(url);
        var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
        
        var stream = await _youtubeClient.Videos.Streams.GetAsync(streamInfo);
        return (stream, NormalizeTitleFile(video.Title, "mp3"), "audio/mp3");
    }
    
    public async Task<(Stream File, string FileName, string ContentType)> ConvertToMp4(string url)
    {
        var video = await _youtubeClient.Videos.GetAsync(url);
        
        var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(url);
        var streamInfo = streamManifest.GetVideoOnlyStreams().GetWithHighestBitrate();
        
        var stream = await _youtubeClient.Videos.Streams.GetAsync(streamInfo);
        return (stream, NormalizeTitleFile(video.Title, "mp4"), "video/mp4");
    }

    private static string NormalizeTitleFile(string title, string extension) =>
        $"{title.Replace(' ', '-')}.{extension}";
}