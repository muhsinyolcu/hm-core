using System.Diagnostics;

namespace HM.Core.Extensions;

public static class StopwatchExtensions
{
    public static long ElapsedTicks(this Stopwatch sw)
    {
        return sw.ElapsedTicks;
    }
    public static long ElapsedMilliseconds(this Stopwatch sw)
    {
        return sw.ElapsedMilliseconds;
    }
    public static long ElapsedSeconds(this Stopwatch sw)
    {
        return sw.ElapsedMilliseconds / 1000;
    }
}