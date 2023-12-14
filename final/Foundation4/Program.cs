using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create activities
        Activity runningActivity = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        Activity cyclingActivity = new Cycling(new DateTime(2022, 11, 3), 30, 20);
        Activity swimmingActivity = new Swimming(new DateTime(2022, 11, 3), 30, 10);

        // Create a list of activities
        List<Activity> activities = new List<Activity>
        {
            runningActivity,
            cyclingActivity,
            swimmingActivity
        };

        // Display summary for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}

class Activity
{
    private DateTime date;
    protected int minutes; // Change access modifier to protected

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Default implementation, to be overridden in derived classes
    }

    public virtual double GetSpeed()
    {
        return 0; // Default implementation, to be overridden in derived classes
    }

    public virtual double GetPace()
    {
        return 0; // Default implementation, to be overridden in derived classes
    }

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} - {GetType().Name} ({minutes} min)";
    }
}

class Running : Activity
{
    private double distance;

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / minutes * 60;
    }

    public override double GetPace()
    {
        return minutes / distance;
    }

    public override string GetSummary()
    {
        return base.GetSummary() +
               $": Distance {distance:F2} miles, Speed {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetDistance()
    {
        return speed * minutes / 60;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    public override string GetSummary()
    {
        return base.GetSummary() +
               $": Distance {GetDistance():F2} miles, Speed {speed:F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000; // Convert laps to kilometers
    }

    public override double GetSpeed()
    {
        return GetDistance() / minutes * 60;
    }

    public override double GetPace()
    {
        return minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return base.GetSummary() +
               $": Distance {GetDistance():F2} km, Speed {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}
