using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select an activity (1/2/3/4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ExecuteActivity(new BreathingActivity());
                    break;
                case "2":
                    ExecuteActivity(new ReflectionActivity());
                    break;
                case "3":
                    ExecuteActivity(new ListingActivity());
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid activity.");
                    break;
            }
        }
    }

    static void ExecuteActivity(Activity activity)
    {
        Console.Clear();
        activity.Start();
        Console.Clear();
        activity.End();
        Console.Clear();
    }
}
