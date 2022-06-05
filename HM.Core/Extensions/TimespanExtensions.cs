namespace HM.Core.Extensions;

public static class TimespanExtensions
{
    /// <summary>
    /// Gets timespan with <paramref name="n"/> days.
    /// </summary>
    public static TimeSpan Days(this int n)
    {
        return TimeSpan.FromDays(n);
    }

    /// <summary>
    /// Gets timespan with <paramref name="n"/> hours.
    /// </summary>
    public static TimeSpan Hours(this int n)
    {
        return TimeSpan.FromHours(n);
    }

    /// <summary>
    /// Gets timespan with <paramref name="n"/> minutes.
    /// </summary>
    public static TimeSpan Minutes(this int n)
    {
        return TimeSpan.FromMinutes(n);
    }

    /// <summary>
    /// Gets timespan with <paramref name="n"/> seconds.
    /// </summary>
    public static TimeSpan Seconds(this int n)
    {
        return TimeSpan.FromSeconds(n);
    }

    /// <summary>
    /// Gets timespan with <paramref name="n"/> milliseconds.
    /// </summary>
    public static TimeSpan Milliseconds(this int n)
    {
        return TimeSpan.FromMilliseconds(n);
    }
}