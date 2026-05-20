using System;

namespace DailyJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is going to be the main program class
            Journal myJournal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();
            bool keepRunning = true;

            Console.WriteLine("Welcome to the Daily Journal Program!");

            while (keepRunning)
            {
                //options for the user to select what to do in the program
                Console.WriteLine("\nPlease select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");
                
                string choice = Console.ReadLine(); 

                switch (choice)
                {
                    case "1":
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("> ");
                        string response = Console.ReadLine();
                        
                        string dateText = DateTime.Now.ToShortDateString();

                        Entry newEntry = new Entry(dateText, prompt, response);
                        myJournal.AddEntry(newEntry);
                        break;

                    case "2":
                        Console.WriteLine();
                        myJournal.DisplayAll();
                        break;

                    case "3":
                        Console.Write("What is the filename to load from? (e.g., journal.txt): ");
                        string loadFile = Console.ReadLine();
                        myJournal.LoadFromFile(loadFile);
                        break;

                    case "4":
                        Console.Write("What is the filename to save to? (e.g., journal.txt): ");
                        string saveFile = Console.ReadLine();
                        myJournal.SaveToFile(saveFile);
                        break;

                    case "5":
                        keepRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}