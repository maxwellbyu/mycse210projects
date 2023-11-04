using System;
using System.Collections.Generic;
using System.Linq;

class Word
{
    public string Text { get; set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public void Display()
    {
        if (IsHidden)
        {
            Console.Write("[HIDDEN] ");
        }
        else
        {
            Console.Write(Text + " ");
        }
    }
}

class Reference
{
    public string Text { get; set; }

    public Reference(string text)
    {
        Text = text;
    }

    public void Display()
    {
        Console.WriteLine("Scripture Reference: " + Text);
    }
}

class Scripture
{
    private List<Word> words;
    private Reference reference;

    public Scripture(string referenceText, string scriptureText)
    {
        reference = new Reference(referenceText);
        words = scriptureText.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        reference.Display();
        foreach (var word in words)
        {
            word.Display();
        }
        Console.WriteLine();
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int index = random.Next(0, words.Count);
        words[index].Hide();
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}

class Program
{
    static void Main(string[] args)
    {
        string referenceText = "Proverbs 3:5";
        string scriptureText = "Trust in the LORD with all thine heart; and lean not unto thine own understanding.";

        Scripture scripture = new Scripture(referenceText, scriptureText);

        while (!scripture.AllWordsHidden())
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWord();
            Console.Clear();
        }
    }
}
