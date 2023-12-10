using System;

// Abstraction: 
public abstract class CalculatorOperation
{
    // Abstract method 
    public abstract double PerformOperation(double num1, double num2);
}

// Inheritance:
public class AdditionOperation : CalculatorOperation
{
    public override double PerformOperation(double num1, double num2)
    {
        return num1 + num2;
    }
}

public class SubtractionOperation : CalculatorOperation
{
    public override double PerformOperation(double num1, double num2)
    {
        return num1 - num2;
    }
}

public class MultiplicationOperation : CalculatorOperation
{
    public override double PerformOperation(double num1, double num2)
    {
        return num1 * num2;
    }
}

public class DivisionOperation : CalculatorOperation
{
    public override double PerformOperation(double num1, double num2)
    {
        if (num2 != 0)
        {
            return num1 / num2;
        }
        else
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            return double.NaN; // NaN (Not a Number) represents an undefined result.
        }
    }
}

// Encapsulation: 
public class Calculator
{
    // Polymorphism: Use an array
    private CalculatorOperation[] operations;

    public Calculator()
    {
        // Initialize operations
        operations = new CalculatorOperation[]
        {
            new AdditionOperation(),
            new SubtractionOperation(),
            new MultiplicationOperation(),
            new DivisionOperation()
        };
    }

    // Perform a calculation 
    public double Calculate(double num1, double num2, int operationChoice)
    {
        if (operationChoice >= 0 && operationChoice < operations.Length)
        {
            CalculatorOperation selectedOperation = operations[operationChoice];
            return selectedOperation.PerformOperation(num1, num2);
        }
        else
        {
            Console.WriteLine("Error: Invalid operation choice.");
            return double.NaN;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Simple Calculator!");

        Console.Write("Enter the first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Select an operation: ");
        Console.WriteLine("0. Addition");
        Console.WriteLine("1. Subtraction");
        Console.WriteLine("2. Multiplication");
        Console.WriteLine("3. Division");

        Console.Write("Enter your choice (0-3): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        // Abstraction and Encapsulation: Create an instance of the Calculator class.
        Calculator calculator = new Calculator();

        // Polymorphism: Use the Calculator instance to perform the calculation.
        double result = calculator.Calculate(num1, num2, choice);

        Console.WriteLine($"The result is: {result}");
    }
}
