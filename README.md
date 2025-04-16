using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter integers separated by spaces:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("No input provided.");
                return;
            }

            // Convert input string to list of integers
            List<int> numbers = input.Split(' ')
                                     .Select(int.Parse)
                                     .ToList();

            // Use a HashSet to track seen numbers
            HashSet<int> seen = new HashSet<int>();

            foreach (int number in numbers)
            {
                if (!seen.Add(number))
                {
                    throw new InvalidOperationException($"Duplicate number found: {number}");
                }
            }

            Console.WriteLine("All numbers are unique.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter only integers separated by spaces.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
=============================================
===========================================
using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            CheckForVowels(input);

            Console.WriteLine("The string contains at least one vowel.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Method to check for vowels in a string
    static void CheckForVowels(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new ArgumentException("Input string cannot be null or empty.");
        }

        bool hasVowel = false;

        // Convert to lowercase to make comparison case-insensitive
        for (int i = 0; i < str.Length; i++)
        {
            char ch = char.ToLower(str[i]);
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
            {
                hasVowel = true;
                break;
            }
        }

        if (!hasVowel)
        {
            throw new Exception("The string does not contain any vowels.");
        }
    }
}

