using Transmutatio.Domain.Conversions.Enums;

namespace Transmutatio.Application.Conversions.DTOs;

public record YoutubeConversionRequest(
    string Url,
    TargetFormat Format
);