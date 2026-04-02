// FILE: Program.cs
// RESPONSIBILITY: Application entry point.
// The file knows nothing about how the algorithms works. 
// It only knows that it can call Processor and display what comes back.

using System;

namespace DedupeSortInts
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Deduplicate and Sort Integers");
            Console.WriteLine();
            Console.WriteLine("This program reads a space-separated list of integers,");
            Console.WriteLine("removes duplicates, and returns them sorted in ascending order.");
            Console.WriteLine();

            try
            {
                Console.Write("Enter integers (space-separated): ");
                // Handle Ctrl+C or end-of-stream (rawInput can be null in some environments)
                string? rawInput = Console.ReadLine() ?? string.Empty;

                // Run the Algorithm
                string output = Processor.FilterSort(rawInput);

                // Display Results
                Console.WriteLine();
                Console.WriteLine($"Input: \"{rawInput}\"");

                if (string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Output: (no valid integers found in input)");
                }
                else
                {
                    Console.WriteLine($"Output: \"{output}\"");
                }

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.GetType()}: {ex.Message}");
            }
        }
    }
}