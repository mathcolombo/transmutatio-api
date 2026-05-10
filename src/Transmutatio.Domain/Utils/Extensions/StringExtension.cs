namespace Transmutatio.Domain.Utils.Extensions;

public static class StringExtension
{
    public static void Validate(this string str, int maxLength = 255)
    {
        if(string.IsNullOrWhiteSpace(str))
            throw new ArgumentException("String cannot be null, empty, or whitespace.");
        
        if(str.Length >= maxLength)
            throw new FormatException("String is too long");
    }
}