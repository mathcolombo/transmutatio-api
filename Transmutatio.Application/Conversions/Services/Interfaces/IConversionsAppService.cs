using Transmutatio.Application.Conversions.Dtos;

namespace Transmutatio.Application.Conversions.Services.Interfaces;

public interface IConversionsAppService
{ 
    Task<(Stream File, string FileName, string ContentType)> Convert(ConversionInsertRequest request);
}