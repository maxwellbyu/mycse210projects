using System;
using System.Threading;

// This defines a class to encapsulate
class ScriptureDisplayer
{
    private string fullScripture;
    private string[] words;

    // Constructor for text initialization
    public ScriptureDisplayer(string scripture)
    {
        fullScripture = scripture;
        words = fullScripture.Split(' ');
    }

    // Method to display word by word
    public void DisplayScripture()
    {
        for (int i = 0; i < words.Length; i++)
        {
            Console.Write(words[i] + " "); // Display the word
            Thread.Sleep(1000); // Pause for 1 second
            Console.SetCursorPosition(Console.CursorLeft - words[i].Length - 1, Console.CursorTop);
            Console.Write(new string(' ', words[i].Length + 1)); // Clear the word
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Define the scripture text
        string scripture = "For God so loved the world that He gave His only begotten Son, that whoever believes in Him shall not perish but have eternal life.";

        // Create an instance of ScriptureDisplayer
        ScriptureDisplayer displayer = new ScriptureDisplayer(scripture);

        // Display the scripture using the ScriptureDisplayer class
        displayer.DisplayScripture();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
