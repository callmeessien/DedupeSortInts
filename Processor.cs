// FILE: Processor.cs
// RESPONSIBILITY: Orchestrate the full pipeline:
//  1. Parse input string into integers (via InputParser)
//  2. Deduplicate using a HashSet
//  3. Sort using Merge Sort (via MergeSorter)
//  4. Format the result as a space-separated string
// This class is the coordinator. 
// It knows the overall strategy but delegates individual concerns to specialist classes.

using System;

namespace FilterSortInts
{
    public static class Processor
    {
        public static string FilterSort(string input)
        {
            // PARSE
            // Time: O(n) where n = number of tokens
            List<int> allNumbers = InputParser.Parse(input);

            // If parsing produced nothing (empty input, all-invalid tokens), return empty string.
            if (allNumbers.Count == 0)
            {
                return string.Empty;
            }

            // DEDUPLICATE USING HASHSET
            // HashSet internally uses a hash table. 
            // Each .Add() computes a hash of the integer in O(1) average time. 
            // If the value already exists in the set, .Add() returns false and the value is not added.
            // This gives us O(n) total for the entire deduplication phase.
            // Alternative we are avoiding: manually checking if a number is already in a List. O(n^2)
            // Time: O(n) average case / Space: O(k) where k = number of unique values
            HashSet<int> uniqueSet = new HashSet<int>();

            foreach (int number in allNumbers)
            {
                uniqueSet.Add(number);
            }

            // Convert to List to enable sorting.
            List<int> uniqueList = new List<int>(uniqueSet);

            // If there is 0 or 1 unique element, it is already sorted. No need to Merge Sort.
            if (uniqueList.Count <= 1)
            {
                return string.Join(" ", uniqueList);
            }

            // SORT USING MERGE SORT
            // Time: O(k log k) / Space: O(k) for the auxiliary merge arrays
            List<int> sortedUniques = MergeSorter.Sort(uniqueList);

            // FORMAT
            // Time: O(k) - visits each element once
            string result = string.Join(" ", sortedUniques);

            return result;
        }
    }
}