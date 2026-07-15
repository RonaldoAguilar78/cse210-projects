using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int lengthMinutes, double speed) 
        : base(date, lengthMinutes)
    {
        _speed = speed;
    }

    // Setter for speed (GetSpeed is handled by the override)
    public void SetSpeed(double speed) { _speed = speed; }

    // Overridden methods
    public override double GetDistance()
    {
        return (_speed * GetLengthMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}