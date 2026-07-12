using System.ComponentModel;
using System.Reflection;

namespace Transmutatio.Domain.Utils.Extensions;

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        Type type = value.GetType();

        string name = Enum.GetName(type, value);
        if (name == null) return value.ToString();

        FieldInfo field = type.GetField(name);
        if (field == null) return value.ToString();

        var attribute = field.GetCustomAttribute<DescriptionAttribute>();

        return attribute != null ? attribute.Description : value.ToString();
    }
}