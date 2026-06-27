using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            DisplayPlayerInfo();
            
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": quit = true; break;
                default: Console.WriteLine("Invalid choice. Try again."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            // Because of POLYMORPHISM, we can just call GetDetailsString() 
            // and the program automatically knows whether to run the Simple, 
            // Eternal, or Checklist version of the method!
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _goals.Count)
        {
            Goal selectedGoal = _goals[choice - 1];

            // We check if the goal was already complete BEFORE recording the event
            bool wasCompleteBefore = selectedGoal.IsComplete();

            // Record the event in the specific goal
            selectedGoal.RecordEvent();

            // Parse the string points to an integer to add to the score
            int pointsEarned = int.Parse(selectedGoal.Points);

            // If it is a checklist goal, and it JUST became complete, add the bonus!
            if (selectedGoal is ChecklistGoal checklistGoal && !wasCompleteBefore && selectedGoal.IsComplete())
            {
                pointsEarned += checklistGoal.Bonus;
            }

            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            // First line is always the total score
            outputFile.WriteLine(_score);

            // Subsequent lines are the string representation of each goal
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            
            // Clear current list before loading new ones
            _goals.Clear(); 
            
            // Read the score from the first line
            _score = int.Parse(lines[0]);

            // Loop through the rest of the lines starting at index 1
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                if (type == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(details[0], details[1], details[2], bool.Parse(details[3])));
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(details[0], details[1], details[2]));
                }
                else if (type == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(details[0], details[1], details[2], int.Parse(details[3]), int.Parse(details[4]), int.Parse(details[5])));
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}