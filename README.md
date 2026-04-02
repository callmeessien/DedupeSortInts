# DedupeSortInts

Deduplicates and sorts integers from a space-separated input string, returning results in ascending order.

---

## Overview

Given a string of space-separated integers, this program removes duplicate values, sorts the unique results, and returns them as a clean space-separated string. The solution prioritizes correctness, deterministic behavior, and algorithmic transparency. Time and space complexity are treated as first-class concerns.

---

## Project Structure

```
DedupeSortInts/
├── Program.cs        — Entry point. Handles I/O only. No algorithm logic.
├── InputParser.cs    — Splits and parses raw string input into List<int>.
├── MergeSorter.cs    — Implements Merge Sort. Isolated, independently testable.
└── Processor.cs      — Pipeline coordinator: parse → deduplicate → sort → format.
```

Each file has a single, well-defined responsibility. No class owns more than one concern.

---

## Algorithm Summary

```
1. Parse    — Split input on whitespace. Parse each token with int.TryParse.
               Invalid tokens are skipped. Negatives are supported.

2. Dedupe   — Insert all parsed integers into a HashSet<int>.
               Duplicates are rejected automatically in O(1) average time.

3. Sort     — Convert the HashSet to a List<int>.
               Sort using an explicit Merge Sort implementation.

4. Format   — Join sorted values with a single space and return.
```

---

## Complexity

| Phase         | Complexity       | Notes                                      |
|---------------|------------------|--------------------------------------------|
| Parsing       | O(n)             | n = number of tokens in input              |
| Deduplication | O(n) average     | HashSet insertion is O(1) average per item |
| Sorting       | O(k log k)       | k = unique values; k ≤ n always            |
| Formatting    | O(k)             | Single pass over sorted unique values      |
| **Overall**   | **O(n + k log k)** | Reduces to O(n log n) when all values are unique |

---

## Example

```
Input:  5 8 2 10 6 3 8 2
Output: 2 3 5 6 8 10

Input:  -1 -5 -3 -9 -6 -2 -1
Output: -9 -6 -5 -3 -2 -1
```

---

## Build and Run

Requires [.NET 6](https://dotnet.microsoft.com/download) or later.

```bash
dotnet build
dotnet run
```

---

## Design Notes

The project applies a strict separation of concerns. `Program.cs` handles only console I/O. `InputParser` handles only string-to-integer conversion. `MergeSorter` handles only sorting. `Processor` owns only the pipeline sequence. No class crosses into another's responsibility.

Merge Sort was chosen over the built-in `List.Sort()` for transparency: every comparison and merge operation is explicit and traceable. The algorithm is stable and guarantees O(k log k) in all cases (best, average, and worst) with no degenerate behavior.