using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 University Dr", "Rexburg", "ID", "USA");
        Address address2 = new Address("450 Corporate Way", "Seattle", "WA", "USA");
        Address address3 = new Address("789 Park Lane", "Austin", "TX", "USA");

        // Create events
        Lecture lecture = new Lecture(
            "The Future of AI", 
            "An in-depth look at artificial intelligence in software development.", 
            "10/15/2026", 
            "6:00 PM", 
            address1, 
            "Dr. Alan Turing", 
            250
        );

        Reception reception = new Reception(
            "Tech Networking Mixer", 
            "A casual evening for professionals to meet and connect.", 
            "11/02/2026", 
            "7:30 PM", 
            address2, 
            "rsvp@technetwork.com"
        );

        OutdoorGathering gathering = new OutdoorGathering(
            "Summer Code Camp Picnic", 
            "Annual outdoor gathering for students and alumni with food and games.", 
            "07/20/2026", 
            "12:00 PM", 
            address3, 
            "Sunny with a high of 85°F"
        );

        // Put them in an array to easily iterate through them
        Event[] events = { lecture, reception, gathering };

        // Output the results
        foreach (Event ev in events)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--- SHORT DESCRIPTION ---");
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
            
            Console.WriteLine("--- STANDARD DETAILS ---");
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();
            
            Console.WriteLine("--- FULL DETAILS ---");
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();
        }
    }
}