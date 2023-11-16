using System;
using System.Collections.Generic;
using System.IO;

// Base class for all activities
public abstract class Activity
{
    public string Name { get; set; }
    public int Points { get; set; }

    public abstract void MarkComplete();
    public abstract void RecordEvent();
    public abstract void DisplayStatus();
    public abstract string GetStringRepresentation();
}

// Derived classes for specific goals
public class SimpleGoal : Activity
{
    public int CompletionPoints { get; set; }

    public override void MarkComplete() { }

    public override void RecordEvent() { }

    public override void DisplayStatus() { }

    public override string GetStringRepresentation() =>
        $"SimpleGoal:{Name},{CompletionPoints}";
}

public class EternalGoal : Activity
{
    public int EventPoints { get; set; }

    public override void MarkComplete() { }

    public override void RecordEvent() { }

    public override void DisplayStatus() { }

    public override string GetStringRepresentation() =>
        $"EternalGoal:{Name},{EventPoints}";
}

public class ChecklistGoal : Activity
{
    public int RequiredCompletions { get; set; }
    public int BonusPoints { get; set; }
    private int completions;

    public override void MarkComplete() { }

    public override void RecordEvent()
    {
        completions++;
        if (completions == RequiredCompletions)
        {
            Points += BonusPoints;
            MarkComplete();
        }
    }

    public override void DisplayStatus() { }

    public override string GetStringRepresentation() =>
        $"ChecklistGoal:{Name},{RequiredCompletions},{BonusPoints}";
}

// User class to manage goals and scores
public class User
{
    public List<Activity> Goals { get; set; } = new List<Activity>();
    public int TotalScore { get; set; }

    public void CreateGoal(string goalType, string goalName, int completionPoints = 0, int eventPoints = 0, int requiredCompletions = 0, int bonusPoints = 0)
    {
        Activity goal = goalType switch
        {
            "Simple" => new SimpleGoal { Name = goalName, CompletionPoints = completionPoints },
            "Eternal" => new EternalGoal { Name = goalName, EventPoints = eventPoints },
            "Checklist" => new ChecklistGoal { Name = goalName, RequiredCompletions = requiredCompletions, BonusPoints = bonusPoints },
            _ => null
        };

        Goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        Activity goal = Goals.Find(g => g.Name == goalName);
        goal?.RecordEvent();
        TotalScore += goal?.Points ?? 0;
    }

    public void DisplayGoals() =>
        Goals.ForEach(g => g.DisplayStatus());

    public void SaveGoalsToFile(string fileName) =>
        File.WriteAllLines(fileName, Goals.Select(g => g.GetStringRepresentation()));

    public void LoadGoalsFromFile(string fileName)
    {
        Goals.Clear();
        File.ReadAllLines(fileName)
            .Select(line =>
            {
                string[] parts = line.Split(":");
                string goalType = parts[0];
                string[] details = parts[1].Split(",");

                return goalType switch
                {
                    "SimpleGoal" => new SimpleGoal { Name = details[0], CompletionPoints = int.Parse(details[1]) },
                    "EternalGoal" => new EternalGoal { Name = details[0], EventPoints = int.Parse(details[1]) },
                    "ChecklistGoal" => new ChecklistGoal { Name = details[0], RequiredCompletions = int.Parse(details[1]), BonusPoints = int.Parse(details[2]) },
                    _ => null
                };
            })
            .Where(goal => goal != null)
            .ToList()
            .ForEach(goal => Goals.Add(goal));
    }
}

// Main program class
class Program
{
    static void Main()
    {
        User mainUser = new User();

        mainUser.CreateGoal("Simple", "Give a talk", completionPoints: 100);
        mainUser.CreateGoal("Eternal", "Spend time with family", eventPoints: 50);
        mainUser.CreateGoal("Checklist", "Clean the chapel", requiredCompletions: 5, bonusPoints: 200);

        mainUser.RecordEvent("Give a talk");
        mainUser.RecordEvent("Spend time with family");
        mainUser.RecordEvent("Clean the chapel");

        mainUser.DisplayGoals();
        Console.WriteLine($"Total Score: {mainUser.TotalScore}");

        mainUser.SaveGoalsToFile("goals.txt");

        User loadedUser = new User();
        loadedUser.LoadGoalsFromFile("goals.txt");

        loadedUser.DisplayGoals();
        Console.WriteLine($"Total Score: {loadedUser.TotalScore}");
    }
}
