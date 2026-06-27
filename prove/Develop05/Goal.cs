using System;

// The 'abstract' keyword means we cannot create a generic "Goal" directly.
// We can only create specific types of goals that inherit from this class.
public abstract class Goal
{
    // ENCAPSULATION: We make member variables 'private' so they cannot be 
    // accidentally changed from outside the class. 
    private string _shortName;
    private string _description;
    private string _points; // Stored as a string per the UML diagram

    // Constructor to initialize the base properties
    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Properties (Getters) to allow read-only access to our private fields
    // This allows the GoalManager to read the names and points without changing them.
    public string Name => _shortName;
    public string Description => _description;
    public string Points => _points;

    // ABSTRACT METHODS: These have no body in the base class. 
    // We are forcing every derived class (child class) to write its own version 
    // of these methods. This is a key part of POLYMORPHISM.
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    // VIRTUAL METHOD: This provides a default implementation that works for most goals,
    // but allows child classes (like ChecklistGoal) to override it if they need to.
    public virtual string GetDetailsString()
    {
        // If the goal is complete, put an X in the box. Otherwise, leave it empty.
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }
}