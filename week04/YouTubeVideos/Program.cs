using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold the Video objects
        List<Video> videos = new List<Video>();

        // Create the first video and add comments
        Video video1 = new Video("C# Programming Basics", "Code Academy", 1200);
        video1.AddComment("Alice", "This video was so helpful!");
        video1.AddComment("Bob", "I learned a lot, thank you!");
        video1.AddComment("Charlie", "Great content, but the audio could be better.");
        videos.Add(video1);

        // Create the second video and add comments
        Video video2 = new Video("How to Bake a Cake", "The Baking Guru", 650);
        video2.AddComment("Diana", "My cake turned out perfect!");
        video2.AddComment("Eve", "Can you do a video on frosting next?");
        video2.AddComment("Frank", "This is the easiest recipe I've ever seen.");
        video2.AddComment("Grace", "Loved the tips on mixing the batter.");
        videos.Add(video2);

        // Create the third video and add comments
        Video video3 = new Video("Beginner's Guide to Gardening", "Green Thumbs", 900);
        video3.AddComment("Heidi", "I'm a total beginner, and this was easy to follow.");
        video3.AddComment("Ivan", "What about gardening in cold climates?");
        video3.AddComment("Judy", "The tips on soil preparation were invaluable.");
        videos.Add(video3);

        // Iterate through the list of videos and display their information
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length (seconds): {video._length}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            // Iterate through the comments for each video
            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"- {comment._name}: {comment._text}");
            }
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
        }
    }
}