using System;

public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail) 
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    // Getter and Setter methods
    public string GetRsvpEmail() { return _rsvpEmail; }
    public void SetRsvpEmail(string rsvpEmail) { _rsvpEmail = rsvpEmail; }

    // Overriding base methods
    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n" +
               $"Event Type: Reception\n" +
               $"RSVP Email: {_rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Reception: {GetTitle()} ({GetDate()})";
    }
}