using System;
//In this class the user can input entries for the journal
namespace DailyJournal
{
    public class Entry
    {
        private string _date;
        private string _promptText;
        private string _entryText;

        public Entry(string date, string promptText, string entryText)
        {
            _date = date;
            _promptText = promptText;
            _entryText = entryText;
        }

        // Explicit getter methods instead of properties or expression-bodied members
        public string GetDate()
        {
            return _date;
        }

        public string GetPromptText()
        {
            return _promptText;
        }

        public string GetEntryText()
        {
            return _entryText;
        }

        public void Display()
        {
            Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
            Console.WriteLine($"{_entryText}");
            Console.WriteLine(); // Add a blank line for readability between entries
        }
    }
}