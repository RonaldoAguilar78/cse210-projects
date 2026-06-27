using System;

class Program
{
    static void Main(string[] args)
    {
        // We create a new instance of the GoalManager class.
        // This class acts as the "controller" for the entire program.
        GoalManager manager = new GoalManager();
        
        // Start the main menu loop
        manager.Start();
    }
}