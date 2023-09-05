namespace SimpleScheduler.Domain;

public enum Interval
{
    EverySecond,
    EveryMinute,
    EveryHour
}

public static class IntervalExtensions
{
    public static long GetTickCounts(this Interval interval)
    {
        switch (interval)
        {
            case Interval.EverySecond:
                return 1000;
            case Interval.EveryMinute:
                return 60000;
            case Interval.EveryHour:
                return 360000;
            default:
                throw new ArgumentOutOfRangeException(nameof(interval), interval, null);
        }
    }
}
