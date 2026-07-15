using System;

public class Running : Activity
{
    private double _distance;

    public Running(string date, int lengthMinutes, double distance) 
        : base(date, lengthMinutes)
    {
        _distance = distance;
    }

    // Setter for distance (GetDistance is handled by the override)
    public void SetDistance(double distance) { _distance = distance; }

    // Overridden methods
    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetLengthMinutes()) * 60;
    }

    public override double GetPace()
    {
        return (double)GetLengthMinutes() / _distance;
    }
}