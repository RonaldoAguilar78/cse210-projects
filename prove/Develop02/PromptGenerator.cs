using System;
using System.Collections.Generic;
//This prompt generator provides the user with a question about the day to input in the journal
namespace DailyJournal
{
    public class PromptGenerator
    {
        private List<string> _prompts;

        public PromptGenerator()
        {
            _prompts = new List<string>();
            _prompts.Add("Who was the most interesting person I interacted with today?");
            _prompts.Add("What was the best part of my day?");
            _prompts.Add("How did I see the hand of the Lord in my life today?");
            _prompts.Add("What was the strongest emotion I felt today?");
            _prompts.Add("If I had one thing I could do over today, what would it be?");
            _prompts.Add("What is something new I learned today?");
            _prompts.Add("What is a small victory I achieved today?");
        }

        public string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }
    }
}