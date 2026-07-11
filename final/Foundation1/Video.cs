using System;
using System.Collections.Generic;

public class Video
{
    // Private backing fields
    private string _title;
    private string _author;
    private int _length; // In seconds
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public string Author
    {
        get { return _author; }
        set { _author = value; }
    }

    public int Length
    {
        get { return _length; }
        set { _length = value; }
    }

    public List<Comment> Comments
    {
        get { return _comments; }
        set { _comments = value; }
    }

    // Method to add a comment to the list
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method returning the total number of comments
    public int GetCommentCount()
    {
        return _comments.Count;
    }
}