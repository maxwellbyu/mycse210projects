using System;
using System.Threading;

class ScriptureDisplay
{
    private string scripture;
    private string[] words;
    private int currentIndex;

    public string Scripture
    {
        get { return scripture; }
        set { scripture = value; }
    }

    public int CurrentIndex
    {
        get { return currentIndex; }
        private set { currentIndex = value; }
    }

    public ScriptureDisplay(string text)
    {
        Scripture = text;
        words = Scripture.Split(' ');
        CurrentIndex = 0;
    }

    public void DisplayNextWord()
    {
        if (CurrentIndex < words.Length)
        {
            Console.Clear();
            for (int i = 0; i <= CurrentIndex; i++)
            {
                Console.Write(words[i] + " ");
            }
            CurrentIndex++;
        }
        else
        {
            Console.WriteLine("The entire scripture is hidden.");
        }
    }
}

class Program
{
    static void Main()
    {
        string john316 = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        ScriptureDisplay display = new ScriptureDisplay(john316);

        Console.WriteLine("Press any key to hide the words (or Ctrl+C to exit).");
        Console.ReadKey();

        while (true)
        {
            display.DisplayNextWord();
            Thread.Sleep(1000); // Adjust the delay (in milliseconds) between word hiding.
        }
    }
}
