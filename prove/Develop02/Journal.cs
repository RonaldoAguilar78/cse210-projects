using System;
using System.Collections.Generic;
using System.IO;
//This is journal class where the program will save to a file the entry from the user.
namespace DailyJournal
{
    public class Journal
    {
        private List<Entry> _entries;

        public Journal()
        {
            _entries = new List<Entry>();
        }

        public void AddEntry(Entry newEntry)
        {
            _entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("The journal is currently empty.");
                return;
            }

            foreach (Entry entry in _entries)
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
                    foreach (Entry entry in _entries)
                    {
                        // Using getter methods instead of properties
                        outputFile.WriteLine($"{entry.GetDate()}~|~{entry.GetPromptText()}~|~{entry.GetEntryText()}");
                    }
                }
                Console.WriteLine("Journal successfully saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

//This is where the program will load the file and display entries available
        public void LoadFromFile(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    _entries.Clear(); 
                    string[] lines = File.ReadAllLines(filename);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);

                        if (parts.Length == 3)
                        {
                            Entry loadedEntry = new Entry(parts[0], parts[1], parts[2]);
                            _entries.Add(loadedEntry);
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
}