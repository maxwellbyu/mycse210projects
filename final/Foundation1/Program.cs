using System;
using System.Collections.Generic;

// Abstraction: Define an abstract class to represent a generic person.
public abstract class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Abstract method for displaying information
    public abstract void DisplayInfo();
}

// Inheritance: Student inherits from the Person class.
public class Student : Person
{
    public int StudentId { get; set; }

    // Encapsulation: Properties are encapsulated with private access modifiers.
    private List<string> courses = new List<string>();

    // Polymorphism: Override the DisplayInfo method in the derived class.
    public override void DisplayInfo()
    {
        Console.WriteLine($"Student: {Name}, Age: {Age}, Student ID: {StudentId}");
        Console.WriteLine("Courses enrolled:");
        foreach (var course in courses)
        {
            Console.WriteLine($"- {course}");
        }
    }

    // Method to enroll in a course
    public void EnrollInCourse(string course)
    {
        courses.Add(course);
        Console.WriteLine($"{Name} enrolled in {course}.");
    }
}

class Program
{
    static void Main()
    {
        // Creating a student object
        Student student = new Student
        {
            Name = "Maxwell Iwe",
            Age = 20,
            StudentId = 12345
        };

        // Using methods from the base class and derived class
        student.EnrollInCourse("Math");
        student.EnrollInCourse("History");

        // Displaying information using polymorphism
        student.DisplayInfo();
    }
}
