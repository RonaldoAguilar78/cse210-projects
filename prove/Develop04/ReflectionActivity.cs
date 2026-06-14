using System;
using System.Collections.Generic; 
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string> { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult." };
    private List<string> _questions = new List<string> { "Why was this experience meaningful to you?", "How did you feel when it was complete?" };

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        Console.WriteLine($"\n--- {_prompts[rand.Next(_prompts.Count)]} ---");
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write($"\n> {_questions[rand.Next(_questions.Count)]} ");
            ShowSpinner(5);
        }
        DisplayEndingMessage();
    }
}