public class Clock
{
    private readonly int hours;
    private readonly int minutes;

    public Clock(int hours, int minutes)
    {
        int totalMinutes = (hours * 60 + minutes) % 1440;

        if (totalMinutes < 0)
            totalMinutes += 1440;

        this.hours = totalMinutes / 60;
        this.minutes = totalMinutes % 60;
    }

    public Clock Add(int minutesToAdd) => new(this.hours, this.minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => Add(-minutesToSubtract);

    public override bool Equals(object? obj)
    {
        if (obj is Clock other)
        {
            return this.hours == other.hours && this.minutes == other.minutes;
        }
        return false;
    }

    public override int GetHashCode() => this.hours.GetHashCode() ^ this.minutes.GetHashCode();

    public override string ToString() => $"{hours:D2}:{minutes:D2}";
}
