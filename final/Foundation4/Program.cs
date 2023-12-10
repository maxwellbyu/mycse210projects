using System;

// Abstraction: Define an abstract class for a generic shape.
public abstract class Shape
{
    // Abstract method for calculating the area of a shape
    public abstract double CalculateArea();

    // Abstract method for displaying shape details
    public abstract void Display();
}

// Inheritance: Create concrete classes for different types of shapes.
public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public override void Display()
    {
        Console.WriteLine($"Circle - Radius: {Radius}, Area: {CalculateArea()}");
    }
}

public class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public override double CalculateArea()
    {
        return Length * Width;
    }

    public override void Display()
    {
        Console.WriteLine($"Rectangle - Length: {Length}, Width: {Width}, Area: {CalculateArea()}");
    }
}

// Encapsulation: Create a ShapeManager class encapsulating shapes.
public class ShapeManager
{
    private List<Shape> shapes;

    public ShapeManager()
    {
        shapes = new List<Shape>();
    }

    // Polymorphism: Use the Shape base class for flexibility.
    public void AddShape(Shape shape)
    {
        shapes.Add(shape);
        Console.WriteLine("Shape added to the Shape Hierarchy.");
    }

    // Display all shapes in the Shape Hierarchy
    public void DisplayShapes()
    {
        if (shapes.Count == 0)
        {
            Console.WriteLine("No shapes in the Shape Hierarchy.");
        }
        else
        {
            Console.WriteLine("Shape Hierarchy:");
            foreach (var shape in shapes)
            {
                shape.Display();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Shape Hierarchy!");

        ShapeManager shapeManager = new ShapeManager();

        // Abstraction, Encapsulation, and Polymorphism:
        // Allow the user to add shapes until they choose to exit.
        while (true)
        {
            Console.WriteLine("Select a shape to add:");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Display Shapes");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice (1-4): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the radius of the circle: ");
                    double circleRadius = Convert.ToDouble(Console.ReadLine());
                    Circle circle = new Circle(circleRadius);
                    shapeManager.AddShape(circle);
                    break;

                case 2:
                    Console.Write("Enter the length of the rectangle: ");
                    double rectangleLength = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the width of the rectangle: ");
                    double rectangleWidth = Convert.ToDouble(Console.ReadLine());
                    Rectangle rectangle = new Rectangle(rectangleLength, rectangleWidth);
                    shapeManager.AddShape(rectangle);
                    break;

                case 3:
                    shapeManager.DisplayShapes();
                    break;

                case 4:
                    Console.WriteLine("Exiting Shape Hierarchy App. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }
}
