using System;
using System.Media;

public class Greeting
{
    public void PlayVoiceGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("JARVIS START UP.wav");
            player.Play();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Error: The voice greeting file was not found. Please ensure the file exists.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred while playing the greeting: {ex.Message}");
        }
    }

    public void DisplayHeader()
    {
        // Store the entire CyberShield banner as a multi-line string
        string cyberShieldArt = @"
                              (                                
   (            )             )\ )    )          (   (         
   )\  (     ( /(    (   (   (()/( ( /( (     (  )\  )\ )      
 (((_) )\ )  )\())  ))\  )(   /(_)))\()))\   ))\((_)(()/(      
 )\___(()/( ((_)\  /((_)(()\ (_)) ((_)\((_) /((_)_   ((_))     
((/ __|)(_))| |(_)(_))   ((_)/ __|| |(_)(_)(_)) | |  _| |      
 | (__| || || '_ \/ -_) | '_|\__ \| ' \ | |/ -_)| |/ _` |      
  \___|\_, ||_.__/\___| |_|  |___/|_||_||_|\___||_|\__,_|      
       |__/                                                   
";

        // Split the banner into lines and alternate color per line
        string[] lines = cyberShieldArt.Split('\n');
        ConsoleColor[] flameColors = { ConsoleColor.Red, ConsoleColor.DarkYellow };

        for (int i = 0; i < lines.Length; i++)
        {
            Console.ForegroundColor = flameColors[i % flameColors.Length];
            Console.WriteLine(lines[i]);
        }

        // Green bot diagram
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
  _________
 | _______ |
 ||       ||   CYBERSHIELD 3000
 ||_______||   
 |  ___  o|    [Firewall]   [Encryption]   [AI Defense]
 | |___|  |
  (__| |__)
        ");

        // Reset color after all output
        Console.ResetColor();
    }
}