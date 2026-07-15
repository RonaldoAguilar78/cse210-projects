using System;

public class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    // Getter and Setter methods
    public string GetTitle() { return _title; }
    public void SetTitle(string title) { _title = title; }

    public string GetDescription() { return _description; }
    public void SetDescription(string description) { _description = description; }

    public string GetDate() { return _date; }
    public void SetDate(string date) { _date = date; }

    public string GetTime() { return _time; }
    public void SetTime(string time) { _time = time; }

    public Address GetAddress() { return _address; }
    public void SetAddress(Address address) { _address = address; }

    // Message generation methods
    public string GetStandardDetails()
    {
        return $"Title: {_title}\n" +
               $"Description: {_description}\n" +
               $"Date: {_date} | Time: {_time}\n" +
               $"Address: {_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        // Base implementation (can be extended by derived classes)
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        // Base implementation
        return $"Event: {_title} - {_date}";
    }
}