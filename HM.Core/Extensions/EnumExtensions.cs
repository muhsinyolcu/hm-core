namespace HM.Core.Extensions;
public static class EnumExtensions
{
    /// <summary>
    /// Converts an enum to int 32
    /// </summary>
    public static int ToInt32(this Enum value)
    {
        return Convert.ToInt32(value);
    }

    /// <summary>
    /// Converts a string to an enum
    /// </summary>
    /// <exception cref="ArgumentException">Throws if the string can't be converted to the enum</exception>
    public static T ToEnum<T>(this string value)
        where T : struct => (T)Enum.Parse(typeof(T), value);

    /// <summary>
    /// Converts a string to an enum, and uses the fallback value if the string doesn't match any enum values
    /// </summary>
    public static T ToEnumOrDefault<T>(this string value, T fallback)
        where T : struct => Enum.TryParse<T>(value, out var result) ? result : fallback;
}