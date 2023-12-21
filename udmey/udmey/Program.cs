using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        DisplayBanner();

        Console.Write("Enter the path of the input file: ");
        string inputFilePath = Console.ReadLine();

        if (File.Exists(inputFilePath))
        {
            ProcessFile(inputFilePath);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Path Please Check and try again");
            Console.ReadKey();

            return;
        }

        // Inform the user that the work is done
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Work is done. Press any key to close the program.");
        Console.ReadKey();
    }

    static void DisplayBanner()
    {
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("██████╗░░█████╗░██████╗░████████╗  ░██████╗██████╗░██╗░░░░░██╗████████╗████████╗███████╗██████╗░");
        Console.WriteLine("██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝  ██╔════╝██╔══██╗██║░░░░░██║╚══██╔══╝╚══██╔══╝██╔════╝██╔══██╗");
        Console.WriteLine("██████╔╝██║░░██║██████╔╝░░░██║░░░  ╚█████╗░██████╔╝██║░░░░░██║░░░██║░░░░░░██║░░░█████╗░░██████╔╝");
        Console.WriteLine("██╔═══╝░██║░░██║██╔══██╗░░░██║░░░  ░╚═══██╗██╔═══╝░██║░░░░░██║░░░██║░░░░░░██║░░░██╔══╝░░██╔══██╗");
        Console.WriteLine("██║░░░░░╚█████╔╝██║░░██║░░░██║░░░  ██████╔╝██║░░░░░███████╗██║░░░██║░░░░░░██║░░░███████╗██║░░██║");
        Console.WriteLine("╚═╝░░░░░░╚════╝░╚═╝░░╚═╝░░░╚═╝░░░  ╚═════╝░╚═╝░░░░░╚══════╝╚═╝░░░╚═╝░░░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Telegram ==>  @SaidosHits");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("");

    }

    static void ProcessFile(string filePath)
    {
        Dictionary<int, List<string>> portLines = new Dictionary<int, List<string>>();

        // Read the input file line by line
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Extract port number from the line
                int port;
                if (TryExtractPortNumber(line, out port))
                {
                    // Add the line to the corresponding port's list
                    if (!portLines.ContainsKey(port))
                    {
                        portLines[port] = new List<string>();
                    }
                    portLines[port].Add(line);
                }
                // Ignore lines that don't end with a valid port number
            }
        }

        // Save lines to files based on port numbers
        foreach (var kvp in portLines)
        {
            int port = kvp.Key;
            string outputFileName = $"IP_{port}.txt";

            // Save lines to the corresponding file
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                foreach (string line in kvp.Value)
                {
                    writer.WriteLine(line);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"IP's with port {port} saved to {outputFileName}");
        }
    }

    static bool TryExtractPortNumber(string line, out int port)
    {
        // Extract the last four characters from the line
        string lastFourChars = line.Length >= 4 ? line.Substring(line.Length - 4) : "";

        // Try to parse the last four characters as a port number
        return int.TryParse(lastFourChars, out port);
    }
}
