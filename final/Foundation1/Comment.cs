using System;

public class Comment
{
    // Private backing fields
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    // Fully expanded property for Name
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    // Fully expanded property for Text
    public string Text
    {
        get { return _text; }
        set { _text = value; }
    }
}