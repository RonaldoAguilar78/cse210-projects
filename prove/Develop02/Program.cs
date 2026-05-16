using System;
using System.Collections.Generic;
using System.IO;

namespace DailyJournal
{
    // PROGRAM CLASS this will be the main menu, or the entry point selection for what the user wants to do
    class Program
    {
        static void Main(string[] args)
        {
            Journal myJournal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();
            bool keepRunning = true;

            Console.WriteLine("Welcome to the Daily Journal Program!");

            while (keepRunning)
            {
                Console.WriteLine("\nPlease select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");
                
                string choice = Console.ReadLine(); //Here is where the user will select the option

                switch (choice)
                {
                    case "1":
                        // Here is where the user will write a new entry
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("> ");
                        string response = Console.ReadLine();
                        
                        // This will get the date and time to the entry
                        string dateText = DateTime.Now.ToShortDateString();

                        Entry newEntry = new Entry(dateText, prompt, response);
                        myJournal.AddEntry(newEntry);
                        break;

                    case "2":
                        // Display the journal
                        Console.WriteLine();
                        myJournal.DisplayAll();
                        break;

                    case "3":
                        // Load the journal from a file
                        Console.Write("What is the filename to load from? (e.g., journal.txt): ");
                        string loadFile = Console.ReadLine();
                        myJournal.LoadFromFile(loadFile);
                        break;

                    case "4":
                        // Save the journal to a file
                        Console.Write("What is the filename to save to? (e.g., journal.txt): ");
                        string saveFile = Console.ReadLine();
                        myJournal.SaveToFile(saveFile);
                        break;

                    case "5":
                        // Quit
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

    // JOURNAL CLASS
    public class Journal
    {
        public List<Entry> Entries { get; set; }

        public Journal()
        {
            Entries = new List<Entry>();
        }

        public void AddEntry(Entry newEntry)
        {
            Entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            if (Entries.Count == 0)
            {
                Console.WriteLine("The journal is currently empty.");
                return;
            }

            foreach (Entry entry in Entries)
            {
                entry.Display();
            }
        }

        public void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    foreach (Entry entry in Entries)
                    {
                        // Using a unique separator ~|~ to avoid conflict with commas in the user's text
                        outputFile.WriteLine($"{entry.Date}~|~{entry.PromptText}~|~{entry.EntryText}");
                    }
                }
                Console.WriteLine("Journal successfully saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        public void LoadFromFile(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    // Clear existing entries so we can replace them with the loaded ones
                    Entries.Clear(); 
                    string[] lines = File.ReadAllLines(filename);

                    foreach (string line in lines)
                    {
                        // Split the line using our unique separator
                        string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);

                        if (parts.Length == 3)
                        {
                            Entry loadedEntry = new Entry(parts[0], parts[1], parts[2]);
                            Entries.Add(loadedEntry);
                        }
                    }
                    Console.WriteLine("Journal successfully loaded!");
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
            }
        }
    }

    // ==========================================
    // ENTRY CLASS
    // ==========================================
    public class Entry
    {
        public string Date { get; set; }
        public string PromptText { get; set; }
        public string EntryText { get; set; }

        public Entry(string date, string promptText, string entryText)
        {
            Date = date;
            PromptText = promptText;
            EntryText = entryText;
        }

        public void Display()
        {
            Console.WriteLine($"Date: {Date} - Prompt: {PromptText}");
            Console.WriteLine($"{EntryText}");
            Console.WriteLine(); // Add a blank line for readability between entries
        }
    }

    // PROMPT GENERATOR CLASS
    public class PromptGenerator
    {
        public List<string> Prompts { get; set; }

        public PromptGenerator()
        {
            Prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What is something new I learned today?",
                "What is a small victory I achieved today?"
            };
        }

        public string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(Prompts.Count);
            return Prompts[index];
        }
    }
}