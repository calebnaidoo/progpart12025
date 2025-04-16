using System;
using System.Text.RegularExpressions;

public class CybersecurityAwarenessBot
{
    static void Main(string[] args)
    {
        // Play voice greeting
        Greeting greeting = new Greeting();
        greeting.PlayVoiceGreeting();

        // Display header
        greeting.DisplayHeader();

        // User interaction
        Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!");
        Console.Write("What is your name? ");
        string userName = Console.ReadLine();

        // Display greeting in Cyan
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Hello, {userName}! I'm here to help you stay safe online.");
        Console.ResetColor(); // Reset color to default

        // Basic response system
        Response response = new Response();
        while (true)
        {
            Console.WriteLine("\nYou can ask me about password safety, phishing, safe browsing, two-factor authentication, malware, or social engineering.");
            Console.Write("What would you like to know? (Type 'exit' to quit) ");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "exit")
            {
                Console.Write("Are you sure you want to exit? (yes/no): ");
                string confirmExit = Console.ReadLine().ToLower();
                if (confirmExit == "yes")
                {
                    Console.WriteLine("Thank you for using the Cybersecurity Awareness Bot. Stay safe!");
                    break;
                }
                else if (confirmExit == "no")
                {
                    Console.WriteLine("No problem! I'm available for any other questions.");
                }
                else
                {
                    Console.WriteLine("Please respond with 'yes' or 'no'.");
                }
            }
            else if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Please enter a valid question or topic.");
            }
            else
            {
                // Enhanced input validation
                if (userInput.Length > 200)
                {
                    Console.WriteLine("Your input is too long. Please keep it under 200 characters.");
                    continue;
                }

                if (!Regex.IsMatch(userInput, @"^[a-zA-Z0-9\s]*$"))
                {
                    Console.WriteLine("Please use only letters and numbers in your input.");
                    continue;
                }

                // Check for valid keywords
                string[] validKeywords = { "password", "phishing", "safe browsing", "two-factor authentication", "malware", "social engineering" };
                bool isValidInput = validKeywords.Any(keyword => userInput.Contains(keyword));

                if (!isValidInput)
                {
                    Console.WriteLine("Please ask about topics like password safety, phishing, or safe browsing.");
                    continue;
                }

                try
                {
                    response.RespondToUser(userInput, userName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while processing your request: {ex.Message}");
                }
            }
        }
    }
}

