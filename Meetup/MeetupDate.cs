namespace Meetup;

class MeetupDate(int month, int year)
{
    private readonly int _month = month;
    private readonly int _year = year;

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        //Store all dayOfWeek in the current Month in an IEnumerable
        var daysInMonth = Enumerable.Range(1, DateTime.DaysInMonth(_year, _month))
                                                            .Select(day => new DateTime(_year, _month, day))
                                                            .Where(date => date.DayOfWeek == dayOfWeek)
                                                            .ToArray();

        return schedule switch
        {
            Schedule.Teenth => daysInMonth.Where(date => date.Day >= 13 && date.Day <= 19).First(),
            Schedule.First => daysInMonth[0],
            Schedule.Second => daysInMonth[1],
            Schedule.Third => daysInMonth[2],
            Schedule.Fourth => daysInMonth[3],
            Schedule.Last => daysInMonth.Last()
        };

    }
}