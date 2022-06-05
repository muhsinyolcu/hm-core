namespace HM.Core.Extensions;
public static class DateTimeExtensions
{
    /// <summary>
    /// UTC date format string.
    /// </summary>
    public static readonly string UtcDateFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";

    /// <summary>
    /// Gets the UTC datetime format for the date.
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static string ToUtcFormatString(this DateTime date)
    {
        return date.ToUniversalTime().ToString(UtcDateFormat);
    }
}
