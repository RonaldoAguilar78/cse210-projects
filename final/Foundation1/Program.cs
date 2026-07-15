using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videoList = new List<Video>();

        Video video1 = new Video("Intro to C# and Abstraction", "Tech Guru", 840);
        video1.AddComment(new Comment("Alice", "This really cleared up inheritance for me."));
        video1.AddComment(new Comment("Bob", "Could you do a video on interfaces next?"));
        video1.AddComment(new Comment("Charlie", "Great pacing."));
        videoList.Add(video1);

        Video video2 = new Video("Mastering CSS Grid and Flexbox", "Web Dev Simplified", 1200);
        video2.AddComment(new Comment("Dave", "Finally, a responsive layout that makes sense."));
        video2.AddComment(new Comment("Eve", "I always mixed up justify-content and align-items before this."));
        video2.AddComment(new Comment("Frank", "Very helpful examples."));
        videoList.Add(video2);

        Video video3 = new Video("Python to MySQL Database Connection", "Data Insights", 950);
        video3.AddComment(new Comment("Grace", "The CSV parsing trick saved me hours."));
        video3.AddComment(new Comment("Heidi", "Does this work with SQLite as well?"));
        video3.AddComment(new Comment("Ivan", "Clear and concise code."));
        videoList.Add(video3);

        foreach (Video video in videoList)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }
            
            Console.WriteLine(new string('-', 40)); 
        }
    }
}