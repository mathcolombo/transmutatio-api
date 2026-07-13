using Transmutatio.Application.Conversions.DTOs.Requests;
using Transmutatio.Application.Conversions.DTOs.Responses;

namespace Transmutatio.Application.Conversions.Services.Interfaces;

public interface IConversionsAppService
{
    Task<ConversionYoutubeResponse> ConvertYoutubeAsync(ConversionYoutubeRequest request);
}