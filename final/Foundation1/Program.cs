using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create videos
        Video video1 = new Video("Title 1", "Author 1", 120);
        Video video2 = new Video("Title 2", "Author 2", 180);
        Video video3 = new Video("Title 3", "Author 3", 150);

        // Add comments to videos
        video1.AddComment("UserA", "Great video!");
        video1.AddComment("UserB", "I enjoyed it!");

        video2.AddComment("UserC", "Interesting content!");
        video2.AddComment("UserD", "Keep it up!");

        video3.AddComment("UserE", "Awesome video!");

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (var video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length: " + video.Length + " seconds");
            Console.WriteLine("Number of Comments: " + video.GetNumberOfComments());

            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"  {comment.UserName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; } = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(string userName, string text)
    {
        Comments.Add(new Comment(userName, text));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string UserName { get; set; }
    public string Text { get; set; }

    public Comment(string userName, string text)
    {
        UserName = userName;
        Text = text;
    }
}

