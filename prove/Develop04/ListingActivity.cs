using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string> { "Who are people that you appreciate?", "What are personal strengths of yours?" };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by listing them.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine($"--- {_prompts[new Random().Next(_prompts.Count)]} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }
        Console.WriteLine($"You listed {items.Count} items!");
        DisplayEndingMessage();
    }
}