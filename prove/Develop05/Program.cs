using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Base class for all activities
public abstract class Activity
{
    protected string _name;
    protected int _points;
    protected string _description;

    public Activity(string name, int points, string description)
    {
        _name = name;
        _points = points;
        _description = description;
    }

    public abstract void MarkComplete();
    public abstract void RecordEvent();
    public abstract void DisplayStatus();
    public abstract string GetStringRepresentation();
}

// Derived classes for specific goals
public class SimpleGoal : Activity
{
    public SimpleGoal(string name, string description) : base(name, 0, description) { }

    public override void MarkComplete()
    {
        Console.WriteLine($"Simple goal '{_name}' marked complete.");
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Event recorded for simple goal '{_name}'.");
        _points += 100; // Example: Adding 100 points for simplicity
        MarkComplete();
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"Simple goal '{_name}' status: {_description}");
    }

    public override string GetStringRepresentation() =>
        $"SimpleGoal:{_name},{_points},{_description}";
}

public class EternalGoal : Activity
{
    public EternalGoal(string name, string description) : base(name, 0, description) { }

    public override void MarkComplete()
    {
        Console.WriteLine($"Eternal goal '{_name}' marked complete.");
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Event recorded for eternal goal '{_name}'.");
        _points += 50; // Example: Adding 50 points for simplicity
        MarkComplete();
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"Eternal goal '{_name}' status: {_description}");
    }

    public override string GetStringRepresentation() =>
        $"EternalGoal:{_name},{_points},{_description}";
}

public class ChecklistGoal : Activity
{
    protected int _requiredCompletions;
    protected int _bonusPoints;
    private int _completions;

    public ChecklistGoal(string name, string description, int requiredCompletions, int bonusPoints)
        : base(name, 0, description)
    {
        _requiredCompletions = requiredCompletions;
        _bonusPoints = bonusPoints;
    }

    public override void MarkComplete()
    {
        Console.WriteLine($"Checklist goal '{_name}' marked complete.");
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Event recorded for checklist goal '{_name}'.");
        _completions++;
        if (_completions == _requiredCompletions)
        {
            _points += _bonusPoints;
            MarkComplete();
        }
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"Checklist goal '{_name}' status: {_description}");
    }

    public override string GetStringRepresentation() =>
        $"ChecklistGoal:{_name},{_points},{_description},{_requiredCompletions},{_bonusPoints}";
}

// User class to manage goals and scores
public class User
{
    protected List<Activity> _goals = new List<Activity>();
    protected int _totalScore;

    public void CreateGoal(string goalType, string goalName, string description,
        int completionPoints = 0, int eventPoints = 0, int requiredCompletions = 0, int bonusPoints = 0)
    {
        Activity goal = goalType switch
        {
            "Simple" => new SimpleGoal(goalName, description),
            "Eternal" => new EternalGoal(goalName, description),
            "Checklist" => new ChecklistGoal(goalName, description, requiredCompletions, bonusPoints),
            _ => null
        };

        _goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        Activity goal = _goals.Find(g => g.GetStringRepresentation().Contains(goalName));
        goal?.RecordEvent();
        _totalScore += goal?.GetPoints() ?? 0;
    }

    public void DisplayGoals() =>
        _goals.ForEach(g => g.DisplayStatus());

    public void SaveGoalsToFile(string fileName) =>
        File.WriteAllLines(fileName, _goals.Select(g => g.GetStringRepresentation()));

    public void LoadGoalsFromFile(string fileName)
    {
        _goals.Clear();
        File.ReadAllLines(fileName)
            .Select(line =>
            {
                string[] parts = line.Split(":");
                string goalType = parts[0];
                string[] details = parts[1].Split(",");
                string goalName = details[0];
                string description = details[details.Length - 1];

                return goalType switch
                {
                    "SimpleGoal" => new SimpleGoal(goalName, description),
                    "EternalGoal" => new EternalGoal(goalName, description),
                    "ChecklistGoal" => new ChecklistGoal(goalName, description,
                        int.Parse(details[1]), int.Parse(details[2])),
                    _ => null
                };
            })
            .Where(goal => goal != null)
            .ToList()
            .ForEach(goal => _goals.Add(goal));
    }
}

// Main program class
class Program
{
    static void Main()
    {
        User mainUser = new User();

        mainUser.CreateGoal("Simple", "Give a talk", "Description for giving a talk");
        mainUser.CreateGoal("Eternal", "Spend time with family", "Description for spending time with family");
        mainUser.CreateGoal("Checklist", "Clean the chapel", "Description for cleaning the chapel",
            requiredCompletions: 5, bonusPoints: 200);

        mainUser.RecordEvent("Give a talk");
        mainUser.RecordEvent("Spend time with family");
        mainUser.RecordEvent("Clean the chapel");

        mainUser.DisplayGoals();
        Console.WriteLine($"Total Score: {mainUser.GetTotalScore()}");

        mainUser.SaveGoalsToFile("goals.txt");

        User loadedUser = new User();
        loadedUser.LoadGoalsFromFile("goals.txt");

        loadedUser.DisplayGoals();
        Console.WriteLine($"Total Score: {loadedUser.GetTotalScore()}");
    }
}
