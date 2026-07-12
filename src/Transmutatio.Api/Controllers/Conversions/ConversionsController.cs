using Microsoft.AspNetCore.Mvc;
using Transmutatio.Application.Conversions.DTOs;
using Transmutatio.Application.Conversions.DTOs.Responses;
using Transmutatio.Application.Conversions.Services.Interfaces;

namespace Transmutatio.Api.Controllers.Conversions;

[ApiController]
[Route("api/[controller]")]
public class ConversionsController(IConversionsAppService conversionsAppService) : ControllerBase
{
    [HttpPost("youtube")]
    public async Task<IActionResult> ConvertYoutubeAsync([FromBody] YoutubeConversionRequest request)
    {
        try
        {
            ConversionYoutubeResponse result = await conversionsAppService.ConvertYoutubeAsync(request);
            return File(result.FileBytes, result.ContentType, result.DownloadName);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro durante a transmutação da mídia.", details = ex.Message });
        }
    }
}