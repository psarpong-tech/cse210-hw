using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video(
            "Introduction to Programming",
            "Coursera Academy",
            450);

        Video video2 = new Video(
            "How to use CSS Flex Layout",
            "Developer Mission",
            800);

        Video video3 = new Video(
            "Building Your First Webpage",
            "Teacher WebDev",
            610);

        Video video4 = new Video(
            "Object-Oriented-Programming",
            "Developer World",
            550);  

        video1.AddComment(new Comment(
            "Precious",
            "This was very easy to understand"));    

        video1.AddComment(new Comment(
            "Ebenezer",
            "This introduction was very helpful")); 

        video1.AddComment(new Comment(
            "Amie",
            "Thank you for taking your time to explain"));  

        video2.AddComment(new Comment(
            "Antonio",
            "You made it easy for me to start Web Wevelopment"));    

        video2.AddComment(new Comment(
            "Priscilla",
            "This advice was very helpful")); 

        video2.AddComment(new Comment(
            "Esther",
            "This explanation was very helpful"));

        video3.AddComment(new Comment(
            "Augustina",
            "Thank you for the tutorial"));    

        video3.AddComment(new Comment(
            "Austin",
            "Off to build my first page!")); 

        video3.AddComment(new Comment(
            "Gregory",
            "Good job! You're good at what you do"));

        video4.AddComment(new Comment(
            "Emily",
            "I am now motivated to practice the use of classes"));    

        video4.AddComment(new Comment(
            "Craig",
            "You have made abstraction easy to understand")); 

        video4.AddComment(new Comment(
            "Doreen",
            "I love how you explain the concept"));  


        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3,
            video4
        };

       
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }                               
    }
}