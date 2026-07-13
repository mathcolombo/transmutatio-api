using Transmutatio.Domain.Conversions.Enums;

namespace Transmutatio.Application.Conversions.DTOs.Requests;

public record ConversionYoutubeRequest(
    string Url,
    TargetFormat Format
);