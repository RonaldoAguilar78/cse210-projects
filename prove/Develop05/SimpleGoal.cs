using System;

// The ':' symbol means "inherits from". SimpleGoal gets all the properties of Goal.
public class SimpleGoal : Goal
{
    private bool _isComplete;

    // We pass the name, description, and points up to the base class constructor using ': base(...)'
    public SimpleGoal(string name, string description, string points) 
        : base(name, description, points)
    {
        // A simple goal starts out incomplete
        _isComplete = false;
    }

    // Overloaded constructor specifically used for loading saved files
    public SimpleGoal(string name, string description, string points, bool isComplete) 
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // OVERRIDE: We provide the specific logic for a SimpleGoal.
    public override void RecordEvent()
    {
        // When the event is recorded, the goal is permanently marked as complete.
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        // This formats the data so it can be easily saved to a text file.
        return $"SimpleGoal:{GetName()},{GetDescription()},{GetPoints()},{_isComplete}";
    }
}