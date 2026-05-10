using Microsoft.AspNetCore.Mvc;
using Transmutatio.Application.Conversions.Dtos;
using Transmutatio.Application.Conversions.Services.Interfaces;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Transmutatio.Api.Controllers.Conversions;

[ApiController]
[Route("/api/conversions")]
public class ConversionsController : Controller
{
    private readonly IConversionsAppService _conversionsAppService;

    public ConversionsController(IConversionsAppService conversionsAppService)
    {
        _conversionsAppService = conversionsAppService;
    }

    [HttpPost]
    public async Task<IActionResult> Convert([FromBody] ConversionInsertRequest request)
    {
        (Stream file, string fileName, string contentType) = await _conversionsAppService.Convert(request);

        return new FileStreamResult(file, contentType)
        {
            FileDownloadName = fileName
        };
    }
}