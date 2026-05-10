using Transmutatio.Domain.Formats.Entities;
using Transmutatio.Domain.Utils.Extensions;

namespace Transmutatio.Domain.TypeConversions.Entities;

public class TypeConversion
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public int SourceFormatId { get; protected set; }
    public int TargetFormatId { get; protected set; }

    #region Navigates
    
    public Format SourceFormat { get; protected set; }
    public Format TargetFormat { get; protected set; }
    
    #endregion

    public TypeConversion() {}
    
    public TypeConversion(string name,
                          int sourceFormatId,
                          int targetFormatId)
    {
        SetName(name);
        SetSourceFormat(sourceFormatId);
        SetTargetFormat(targetFormatId);
    }

    public void SetName(string name)
    {
        name.Validate();
        Name = name;
    }

    public void SetSourceFormat(int sourceFormatId)
    {
        SourceFormatId = sourceFormatId;
    }

    public void SetTargetFormat(int targetFormatId)
    {
        TargetFormatId = targetFormatId;
    }
}