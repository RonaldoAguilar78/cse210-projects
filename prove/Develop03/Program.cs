using System;

class Program
{
    static void Main(string[] args)
    {
        // Setup the reference and the scripture text
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        
        Scripture scripture = new Scripture(reference, text);
        string userInput = "";

        // Main program loop
        while (userInput != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            
            userInput = Console.ReadLine();

            // If the user pressed enter, hide 3 random words
            if (userInput != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        // Display the final completely hidden scripture before the program ends
        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are hidden. Program ending.");
        }
    }
}