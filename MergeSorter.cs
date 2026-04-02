// FILE: MergeSorter.cs
// RESPONSIBILITY: Sort a List<int> in ascending order using the Merge Sort algorithm.

using System;

namespace FilterSortInts
{
    // Merge Sort Strategy:
    //  DIVIDE: Split the list in half recursively until each sub-list has 1 element (trivially sorted).
    //  CONQUER: Merge pairs of sorted sub-lists into larger sorted sub-lists.
    //  COMBINE: The final merge produces a fully sorted list.
    public static class MergeSorter
    {
        public static List<int> Sort(List<int> list)
        {
            // A null list is treated as empty.
            if (list == null)
            {
                return new List<int>();
            }

            // A list of 0 or 1 elements is already sorted. No work to do.
            if (list.Count <= 1)
            {
                return new List<int>(list); // Return a copy for consistency.
            }

            // Begin the recursive Merge Sort.
            return MergeSort(list);
        }

        private static List<int> MergeSort(List<int> list)
        {
            // BASE CASE: A single element needs no sorting. This is the bottom of the recursion.
            if (list.Count == 1)
            {
                return new List<int>(list);
            }

            // DIVIDE: Find the midpoint and split the list into two halves.
            int midpoint = list.Count / 2;

            // GetRange(start, count) extracts a sub-list. 
            // Left half: indices 0 through midpoint-1
            List<int> leftHalf = list.GetRange(0, midpoint);

            // Right half: indices midpoint through end
            List<int> rightHalf = list.GetRange(midpoint, list.Count - midpoint);

            // CONQUER: Recursively sort each half.
            // The recursion goes all the way down until each half is size 1.
            List<int> sortedLeft = MergeSort(leftHalf);
            List<int> sortedRight = MergeSort(rightHalf);

            // COMBINE: Merge the two sorted halves.
            return Merge(sortedLeft, sortedRight);
        }

        // Merges two sorted lists into one sorted list. 
        // It uses two pointers (i for left, j for right) 
        // At each step, compare the current front elements of both lists. 
        // Take the smaller one into the result.
        private static List<int> Merge (List<int> left, List<int> right)
        {
            // Pre-allocate the result list with the combined size.
            List<int> result = new List<int>(left.Count + right.Count);

            int i = 0; // Pointer into left list
            int j = 0; // Pointer into right list

            // Walk through both lists simultaneously. 
            // At each step, take the smaller of the two current front elements.
            while (i < left.Count && j < right.Count)
            {
                if (left[i] <= right[j])
                {
                    // Left element is smaller (or equal) - take it. 
                    // Equal elements from the left side come first.
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    // Right element is smaller - take it.
                    result.Add(right[j]);
                    j++;
                }
            }

            // At this point, one of the lists may have remaining elements. 
            // The other list is has been fully processed. Since both lists are sorted, 
            // remaining elements are all larger than everything already in result. 
            // Append all remaining left elements.
            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }

            // Append all remaining right elements.
            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }
    }
}