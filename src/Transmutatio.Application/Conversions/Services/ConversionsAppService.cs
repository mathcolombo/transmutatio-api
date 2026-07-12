using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Transmutatio.Application.Conversions.DTOs;
using Transmutatio.Application.Conversions.DTOs.Responses;
using Transmutatio.Application.Conversions.Services.Interfaces;
using Transmutatio.Domain.Conversions.Commands;
using Transmutatio.Domain.Conversions.Services.Interfaces;

namespace Transmutatio.Application.Conversions.Services;

public class ConversionsAppService(
    IConversionsService conversionsService,
    ILogger<ConversionsAppService> logger
) : IConversionsAppService
{
    public async Task<ConversionYoutubeResponse> ConvertYoutubeAsync(YoutubeConversionRequest request)
    {
        const string evento = nameof(ConvertYoutubeAsync);
        
        logger.LogInformation("<{EventId}> | Starting conversion - Format: {Format} - Url: {request.Url}",
            evento, request.Format, request.Url);
        
        var watch = Stopwatch.StartNew();
        
        try
        {
            ConversionYoutubeResultCommand result = await conversionsService.ExecuteYoutubeConversionAsync(request.Url, request.Format);

            watch.Stop();

            logger.LogInformation("<{EventId}> | Conversion successfully completed - Format: {Format} - Url: {request.Url} - ExecutionTime: {ExecutionTime}ms",
                evento, request.Format, request.Url, watch.ElapsedMilliseconds);
            
            return new ConversionYoutubeResponse
            { 
                FileBytes = result.FileBytes,
                ContentType = result.ContentType,
                DownloadName = result.DownloadName
            };
        }
        catch (Exception ex)
        {
            watch.Stop();
            logger.LogError(ex,
                "<{EventId}> | Error while attempting to convert - Format: {Format} - Url: {request.Url} - ExecutionTime: {ExecutionTime}ms",
                evento, request.Format, request.Url, watch.ElapsedMilliseconds);
            throw;
        }
    }
}