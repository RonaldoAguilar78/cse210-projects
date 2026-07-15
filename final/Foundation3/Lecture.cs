using System;

public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity) 
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    // Getter and Setter methods
    public string GetSpeaker() { return _speaker; }
    public void SetSpeaker(string speaker) { _speaker = speaker; }

    public int GetCapacity() { return _capacity; }
    public void SetCapacity(int capacity) { _capacity = capacity; }

    // Overriding base methods
    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n" +
               $"Event Type: Lecture\n" +
               $"Speaker: {_speaker}\n" +
               $"Capacity: {_capacity} attendees";
    }

    public override string GetShortDescription()
    {
        return $"Lecture: {GetTitle()} ({GetDate()})";
    }
}