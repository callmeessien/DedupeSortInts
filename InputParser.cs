// FILE: InputParser.cs
// RESPONSIBILITY: Parse a raw space-separated string of tokens into a clean List<int>

using System;

namespace FilterSortInts
{
    public static class InputParser
    {
        // Why static? This class holds no state. Only provides helper methods.
        // Static is appropriate when you have utility methods with no instance data. 
        // It does not need to store data for individual objects.

        public static List<int> Parse(string input)
        {
            // If the input is null, empty, or only spaces, there is nothing to parse. 
            // Return an empty list.
            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<int>();
            }

            // Split the string on spaces. 
            // StringSplitOptions.RemoveEmptyEntries means consecutive spaces do not produce empty tokens.
            string[] tokens = input.Split(
                new char[] {' '},
                StringSplitOptions.RemoveEmptyEntries
            );

            // Pre-allocate the list with the number of tokens as initial capacity.
            List<int> parsedNumbers = new List<int>(tokens.Length);

            foreach (string token in tokens)
            {
                // int.TryParse attempts to parse the token. 
                // If successful, value is filled and we add it. 
                // If failed, value = 0 and we skip this token.
                if (int.TryParse(token, out int value))
                {
                    parsedNumbers.Add(value);
                }
            }

            return parsedNumbers;
        }
    }
}