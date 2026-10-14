using System;

public abstract class Activity
{
    private DateTime _date;
    private int _length;

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
        
    public virtual string GetSummary()
    {
        string summary = $"{_date:dd MMM yyyy} {GetType().Name} ({_length} min): ";
        summary += $"Distance {GetDistance():0.0} miles, ";
        summary += $"Speed {GetSpeed():0.0} mph, ";
        summary += $"Pace {GetPace():0.0} min per mile";

        return summary;
    }

    public int GetLength()
    {
        return _length;
    }
}