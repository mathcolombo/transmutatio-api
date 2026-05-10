namespace Transmutatio.Application.Conversions.Dtos;

public record ConversionInsertRequest
{
    public string Url { get; init; }
    public TypeConversionEnum TypeConversion { get; init; }
}