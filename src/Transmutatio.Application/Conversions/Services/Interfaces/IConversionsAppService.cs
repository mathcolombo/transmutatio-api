using Transmutatio.Application.Conversions.DTOs;
using Transmutatio.Application.Conversions.DTOs.Responses;
using Transmutatio.Domain.Conversions.Commands;

namespace Transmutatio.Application.Conversions.Services.Interfaces;

public interface IConversionsAppService
{
    Task<ConversionYoutubeResponse> ConvertYoutubeAsync(YoutubeConversionRequest request);
}