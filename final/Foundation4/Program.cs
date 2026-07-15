using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a central list of the base Activity type
        List<Activity> activities = new List<Activity>();

        // Create one of each activity type
        Running run = new Running("14 Jul 2026", 30, 4.8);
        Cycling cycle = new Cycling("15 Jul 2026", 45, 20.0);
        Swimming swim = new Swimming("16 Jul 2026", 20, 30);

        // Add them to the list
        activities.Add(run);
        activities.Add(cycle);
        activities.Add(swim);

        // Iterate through the list and display the polymorphic summary
        Console.WriteLine("--- Exercise Tracking Summary ---\n");
        foreach (Activity act in activities)
        {
            Console.WriteLine(act.GetSummary());
        }
    }
}