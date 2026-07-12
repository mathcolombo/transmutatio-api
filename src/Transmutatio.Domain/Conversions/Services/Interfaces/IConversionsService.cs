using Transmutatio.Domain.Conversions.Commands;
using Transmutatio.Domain.Conversions.Enums;

namespace Transmutatio.Domain.Conversions.Services.Interfaces;

public interface IConversionsService
{
    Task<ConversionYoutubeResultCommand> ExecuteYoutubeConversionAsync(string url, TargetFormat format);
}