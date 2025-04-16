using System;
using System.Collections.Generic;
using System.Threading;

public class Response
{
    public void RespondToUser(string input, string userName)
    {
        // Dictionary for cybersecurity responses
        Dictionary<string, string> responses = new Dictionary<string, string>
        {
            { "password", "Make sure to use strong, unique passwords for each account. Avoid using personal details in your passwords." },
            { "phishing", "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations." },
            { "safe browsing", "Always check the URL of the website you are visiting. Look for 'https://' and a padlock symbol in the address bar." },
            { "two-factor authentication", "Enable two-factor authentication on your accounts for an extra layer of security." },
            { "malware", "Keep your antivirus software updated to protect against malware." },
            { "social engineering", "Be wary of unsolicited communications asking for personal information." }
        };

        Console.ForegroundColor = ConsoleColor.Cyan; // Set color for responses

        // Personalized response
        Console.WriteLine($"Hi {userName}, here’s what I can tell you about that:");

        bool foundResponse = false;
        foreach (var entry in responses)
        {
            if (input.Contains(entry.Key))
            {
                TypeOut(entry.Value);
                foundResponse = true;
                break;
            }
        }

        if (!foundResponse)
        {
            TypeOut("I didn’t quite understand that. You can ask about password safety, phishing, or safe browsing.");
        }

        Console.ResetColor(); // Reset color to default
    }

    private void TypeOut(string message)
    {
        if (message == null)
        {
            Console.WriteLine("Error: The message is null.");
            return;
        }

        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(50); // Simulate typing effect
        }
        Console.WriteLine(); // Move to the next line
    }
}
