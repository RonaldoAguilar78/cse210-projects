using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) 
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // An eternal goal doesn't change state when recorded. 
        // It just grants points (which is handled by GoalManager).
    }

    public override bool IsComplete()
    {
        // Eternal goals are never truly complete!
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Description},{Points}";
    }
}