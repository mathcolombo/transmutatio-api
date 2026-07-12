namespace Transmutatio.Domain.Conversions.Commands;

public class ConversionYoutubeResultCommand
{
    public byte[] FileBytes { get; set; }
    public string ContentType { get; set; }
    public string DownloadName { get; set; }
}