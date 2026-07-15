using System;

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Getter and Setter methods
    public string GetName() { return _name; }
    public void SetName(string name) { _name = name; }

    public Address GetAddress() { return _address; }
    public void SetAddress(Address address) { _address = address; }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}