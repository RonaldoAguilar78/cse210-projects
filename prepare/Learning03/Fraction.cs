using System;

public class Fraction
{
    private int _top;    // Numerator
    private int _bottom; // Denominator

    public Fraction()
    {
        _top = 1;      // Default numerator
        _bottom = 1;   // Default denominator
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber; // Set numerator to the whole number
        _bottom = 1;        // Denominator is 1
    }

    public Fraction(int top, int bottom)
    {
        _top = top;       // Set numerator
        SetBottom(bottom); // Set denominator using the method
    }

    public void SetBottom(int bottom)
    {
        if (bottom != 0) // Check if denominator is not zero
        {
            _bottom = bottom;
        }
        else
        {
            _bottom = 1; // If zero, set it to 1 to avoid division by zero
        }
    }

    public void SetTop(int top)
    {
        _top = top; // Set numerator
    }

    public string GetFractionString()
    {
        return _top + "/" + _bottom; // Return fraction as string
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom; // Return decimal value
    }
}
