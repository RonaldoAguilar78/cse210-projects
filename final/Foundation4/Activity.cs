using System;

public class Activity
{
    private string _date;
    private int _lengthMinutes;

    public Activity(string date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    // Getter and Setter methods
    public string GetDate() { return _date; }
    public void SetDate(string date) { _date = date; }

    public int GetLengthMinutes() { return _lengthMinutes; }
    public void SetLengthMinutes(int lengthMinutes) { _lengthMinutes = lengthMinutes; }

    // Virtual methods for calculations
    public virtual double GetDistance()
    {
        return 0.0;
    }

    public virtual double GetSpeed()
    {
        return 0.0;
    }

    public virtual double GetPace()
    {
        return 0.0;
    }

    // Shared summary method using the virtual methods
    public string GetSummary()
    {
        // this.GetType().Name dynamically gets the class name (Running, Cycling, Swimming)
        return $"{_date} {this.GetType().Name} ({_lengthMinutes} min): " +
               $"Distance {GetDistance():F1} km, " +
               $"Speed: {GetSpeed():F1} kph, " +
               $"Pace: {GetPace():F2} min per km";
    }
}