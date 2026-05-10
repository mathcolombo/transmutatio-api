using Transmutatio.Domain.Conversions.Entities.Enums;
using Transmutatio.Domain.TypeConversions.Entities;
using Transmutatio.Domain.Utils.Entities;
using Transmutatio.Domain.Utils.Extensions;

namespace Transmutatio.Domain.Conversions.Entities;

public class Conversion
{
    public int Id { get; protected set; }
    public int TypeConversionId { get; protected set; }
    public string OriginalFileName { get; protected set; }
    public string Url { get; protected set; }
    public string ConvertedFileName { get; protected set; }
    public StatusConversionEnum Status { get; protected set; }
    public DateTime RequestDate { get; protected set; }
    public DateTime? CompletionDate { get; protected set; }
    public ErrorMessage? ErrorMessage { get; protected set; }

    #region Navigates

    public TypeConversion TypeConversion { get; protected set; }

    #endregion
    
    public Conversion() {}

    public Conversion(int typeConversionId,
        string originalFileName,
        string url)
    {
        SetTypeConversion(typeConversionId);
        SetOriginalFileName(originalFileName);
        SetUrl(url);
        SetStatus(StatusConversionEnum.Pendente);
        SetRequestDate(DateTime.Now);
    }

    public void SetTypeConversion(int typeConversionId)
    {
        TypeConversionId = typeConversionId;
    }

    public void SetOriginalFileName(string originalFileName)
    {
        if (string.IsNullOrWhiteSpace(originalFileName))
            return;
        
        originalFileName.Validate(255);
        OriginalFileName = originalFileName;
    }
    
    public void SetUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return;
        
        url.Validate(255);
        Url = url;
    }    
    
    public void SetConvertedFileName(string convertedFileName)
    {
        if (string.IsNullOrWhiteSpace(convertedFileName))
            return;
        
        convertedFileName.Validate(255);
        ConvertedFileName = convertedFileName;
    }

    public void SetStatus(StatusConversionEnum status)
    {
        Status = status;
    }

    private void SetRequestDate(DateTime requestDate)
    {
        RequestDate = requestDate;
    }

    public void SetCompletionDate(DateTime? completionDate)
    {
        CompletionDate = completionDate;
    }

    public void SetErrorMessage(ErrorMessage errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}