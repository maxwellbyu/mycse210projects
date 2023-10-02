using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Person p1 = new Person();
        p1._firstName = "Mary";
        p1._lastName = "Smith";
        p1._age = 35;

        Person p2 = new Person();
        p2._firstName = "John";
        p2._lastName = "Watkins";
        p2._age = 40;

        List<Person> people = new List<Person>();
        people.Add(p1);
        people.Add(p2);

        foreach (Person p in people)
    {
        Console.WriteLine(p._firstName);
        
    }
    public static void SaveToFile(List<Person> people)
    {
        string filname = "people.txt";

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Person p in people)
            {
                outputFile.WriteLine(p._firstName);
            }
        }
    }
    }
}