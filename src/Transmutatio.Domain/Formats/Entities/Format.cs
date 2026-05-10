using Transmutatio.Domain.Utils.Extensions;

namespace Transmutatio.Domain.Formats.Entities;

public class Format
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }

    public Format() {}
    
    public Format(string name)
    {
        SetName(name);
    }

    public void SetName(string name)
    {
        name.Validate(50);
        Name = name;
    }
}