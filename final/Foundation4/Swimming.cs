using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int lengthMinutes, int laps) 
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    // Getter and Setter methods for laps
    public int GetLaps() { return _laps; }
    public void SetLaps(int laps) { _laps = laps; }

    // Overridden methods
    public override double GetDistance()
    {
        return _laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthMinutes()) * 60;
    }

    public override double GetPace()
    {
        return (double)GetLengthMinutes() / GetDistance();
    }
}