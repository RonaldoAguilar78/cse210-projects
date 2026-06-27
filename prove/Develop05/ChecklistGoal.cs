using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) 
        : base(name, description, points)
    {
        _amountCompleted = 0; // Starts at 0
        _target = target;
        _bonus = bonus;
    }

    // Overloaded constructor for loading saved files
    public ChecklistGoal(string name, string description, string points, int bonus, int target, int amountCompleted) 
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    // Public getter so the GoalManager can access the bonus points when completed
    public int Bonus => _bonus;

    public override void RecordEvent()
    {
        // Increment the completion counter, but don't let it exceed the target
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        // It is complete if the amount completed meets or exceeds the target
        return _amountCompleted >= _target;
    }

    // POLYMORPHISM IN ACTION: We override the virtual method to add the fraction (e.g., 2/5 times).
    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {Name} ({Description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{_bonus},{_target},{_amountCompleted}";
    }
}