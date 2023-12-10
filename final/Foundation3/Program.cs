using System;
using System.Collections.Generic;

// Abstraction: Define an abstract class for a generic task.
public abstract class Task
{
    public string Description { get; set; }

    // Abstract method for displaying task details
    public abstract void DisplayTask();
}

// Inheritance: Create concrete classes for different types of tasks.
public class WorkTask : Task
{
    public override void DisplayTask()
    {
        Console.WriteLine($"[Work Task] {Description}");
    }
}

public class PersonalTask : Task
{
    public override void DisplayTask()
    {
        Console.WriteLine($"[Personal Task] {Description}");
    }
}

// Encapsulation: Create a ToDoList class encapsulating tasks.
public class ToDoList
{
    private List<Task> tasks;

    public ToDoList()
    {
        tasks = new List<Task>();
    }

    // Polymorphism: Use the Task base class for flexibility.
    public void AddTask(Task task)
    {
        tasks.Add(task);
        Console.WriteLine("Task added to the To-Do List.");
    }

    // Display all tasks in the To-Do List
    public void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks in the To-Do List.");
        }
        else
        {
            Console.WriteLine("To-Do List:");
            foreach (var task in tasks)
            {
                task.DisplayTask();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the To-Do List App!");

        ToDoList toDoList = new ToDoList();

        // Loops: Allow the user to add tasks until they choose to exit.
        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add Work Task");
            Console.WriteLine("2. Add Personal Task");
            Console.WriteLine("3. Display Tasks");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice (1-4): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter work task description: ");
                    string workTaskDescription = Console.ReadLine();
                    WorkTask workTask = new WorkTask { Description = workTaskDescription };
                    toDoList.AddTask(workTask);
                    break;

                case 2:
                    Console.Write("Enter personal task description: ");
                    string personalTaskDescription = Console.ReadLine();
                    PersonalTask personalTask = new PersonalTask { Description = personalTaskDescription };
                    toDoList.AddTask(personalTask);
                    break;

                case 3:
                    toDoList.DisplayTasks();
                    break;

                case 4:
                    Console.WriteLine("Exiting To-Do List App. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }
}
