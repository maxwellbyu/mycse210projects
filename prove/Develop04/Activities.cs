using System;
using System.Threading;
using System.Collections.Generic;

class Activity
{
    protected string description;
    protected int duration;
    protected Random random;

    public Activity()
    {
        random = new Random();
    }

    public virtual void Start()
    {
        Console.Write("Enter the duration (in seconds): ");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine(description);
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
    }

    public virtual void End()
    {
        Console.WriteLine("You've done a good job!");
        Console.WriteLine($"Activity completed in {duration} seconds.");
        Thread.Sleep(3000);
    }

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Start()
    {
        base.Start();
        for (int i = 0; i < duration; i += 4)
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(2);
            Console.WriteLine("Breathe out...");
            PauseWithAnimation(2);
        }
        base.End();
    }
}

class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        // Add more reflection questions here...
    };

    public ReflectionActivity()
    {
        description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void Start()
    {
        base.Start();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000);
        foreach (var question in reflectionQuestions)
        {
            Console.WriteLine(question);
            PauseWithAnimation(4);
        }
        base.End();
    }
}

class ListingActivity : Activity
{
    private List<string> listingPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void Start()
    {
        base.Start();
        string listingPrompt = listingPrompts[random.Next(listingPrompts.Count)];
        Console.WriteLine(listingPrompt);
        Thread.Sleep(2000);

        Console.Write("You have ");
        PauseWithAnimation(duration);
        Console.WriteLine(" items.");

        base.End();
    }
}
