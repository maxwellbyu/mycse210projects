using System;

class Program
{
    static void Main()
    {
        // Generate a random magic number between 1 and 100.
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        Console.WriteLine("Welcome to the Guess My Number game!");

        // Start the game loop.
        while (true)
        {
            Console.Write("What is your guess? ");
            int userGuess;
            if (int.TryParse(Console.ReadLine(), out userGuess))
            {
                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    break; // Exit the loop when the user guesses correctly.
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
