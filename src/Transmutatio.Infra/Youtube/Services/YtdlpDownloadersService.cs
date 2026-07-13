using System.Diagnostics;
using Transmutatio.Domain.Conversions.Enums;
using Transmutatio.Domain.Youtube.Services.Interfaces;

namespace Transmutatio.Infra.Youtube.Services;

public class YtdlpDownloadersService : IYoutubeDownloadersService
{
    public async Task<string> DownloadMediaAsync(string videoUrl, TargetFormat targetFormat, string outputDirectory)
    {
        if (!Directory.Exists(outputDirectory))
            Directory.CreateDirectory(outputDirectory);

        string uniqueId = Guid.NewGuid().ToString();
        string ext = targetFormat == TargetFormat.Mp3 ? "mp3" : "mp4";
        string outputPath = Path.Combine(outputDirectory, $"{uniqueId}.{ext}");

        string commonArgs = "--user-agent \"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36\" --extractor-args \"youtube:player_client=android,web\"";

        string arguments = targetFormat == TargetFormat.Mp3
            ? $"{commonArgs} -x --audio-format mp3 --audio-quality 0 -o \"{outputPath}\" \"{videoUrl}\""
            : $"{commonArgs} -f \"bv*[ext=mp4]+ba[ext=m4a]/b[ext=mp4]\" -o \"{outputPath}\" \"{videoUrl}\"";
        
        var startInfo = new ProcessStartInfo
        {
            FileName = "yt-dlp",
            Arguments = arguments,
            RedirectStandardOutput = false,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process();
        process.StartInfo = startInfo;
        process.Start();
        
        await process.WaitForExitAsync();

        if (process.ExitCode == 0)
            return outputPath;
        
        string error = await process.StandardError.ReadToEndAsync();
        throw new Exception($"Error on yt-dlp (ExitCode {process.ExitCode}): {error}");

    }
}