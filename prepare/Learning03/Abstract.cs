using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void AddEntry(string prompt, string response, string date)
    {
        entries.Add(new JournalEntry { Prompt = prompt, Response = response, Date = date });
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            entries.Clear(); // Clear existing entries before loading from the file.
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        AddEntry(parts[1], parts[2], parts[0]);
                    }
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found. No entries loaded.");
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("Enter your choice (1-5): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("What would you like to do?");
                    Console.Write("Prompt: ");
                    string prompt = Console.ReadLine();
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    journal.AddEntry(prompt, response, date);
                    break;

                case 2:
                    Console.Clear();
                    journal.DisplayEntries();
                    break;

                case 3:
                    Console.Clear();
                    Console.Write("Enter the file name to load the journal: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;

                case 4:
                    Console.Clear();
                    Console.Write("Enter the file name to save the journal: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;

                case 5:
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option (1-5).");
                    break;
            }
        }
    }
}
