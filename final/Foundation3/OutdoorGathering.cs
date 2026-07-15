using System;

public class OutdoorGathering : Event
{
    private string _weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast) 
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    // Getter and Setter methods
    public string GetWeatherForecast() { return _weatherForecast; }
    public void SetWeatherForecast(string weatherForecast) { _weatherForecast = weatherForecast; }

    // Overriding base methods
    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n" +
               $"Event Type: Outdoor Gathering\n" +
               $"Weather Forecast: {_weatherForecast}";
    }

    public override string GetShortDescription()
    {
        return $"Outdoor Gathering: {GetTitle()} ({GetDate()})";
    }
}