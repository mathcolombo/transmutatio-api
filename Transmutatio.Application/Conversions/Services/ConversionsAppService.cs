using Transmutatio.Application.Conversions.Dtos;
using Transmutatio.Application.Conversions.Services.Interfaces;
using Transmutatio.Domain.Conversions.Services.Interfaces;

namespace Transmutatio.Application.Conversions.Services;

public class ConversionsAppService : IConversionsAppService
{
    private readonly IConversionsYoutubeService _conversionsYoutubeService;

    public ConversionsAppService(IConversionsYoutubeService conversionsYoutubeService)
    {
        _conversionsYoutubeService = conversionsYoutubeService;
    }
    
    public async Task<(Stream File, string FileName, string ContentType)> Convert(ConversionInsertRequest request)
    {
        try
        {
            switch (request.TypeConversion)
            {
                case TypeConversionEnum.YoutubeToMp3:
                    return await _conversionsYoutubeService.ConvertToMp3(request.Url);
                case TypeConversionEnum.YoutubeToMp4:
                    return await _conversionsYoutubeService.ConvertToMp4(request.Url);
                default:
                    return await _conversionsYoutubeService.ConvertToMp3(request.Url);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}