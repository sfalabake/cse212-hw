using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Static class containing all recursion problems for CSE 212.
/// </summary>
public static class Recursion
{
    // ########################
    // # Problem 1: SumSquares
    // ########################
    public static int SumSquaresRecursive(int n)
    {
        // Base case: if n <= 0, return 0
        if (n <= 0) return 0;

        // Recursive step: n^2 + sum of squares of previous numbers
        return n * n + SumSquaresRecursive(n - 1);
    }

    // ########################
    // # Problem 2: PermutationsChoose
    // ########################
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: word has reached desired size
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: choose each letter not yet in the word
        foreach (var letter in letters)
        {
            if (!word.Contains(letter))
            {
                PermutationsChoose(results, letters, size, word + letter);
            }
        }
    }

    // ########################
    // # Problem 3: CountWaysToClimb
    // ########################
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) remember = new Dictionary<int, decimal>();

        // Base cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        // Memoization: return cached result if exists
        if (remember.ContainsKey(s)) return remember[s];

        // Recursive call: sum of ways to climb s-1, s-2, s-3 steps
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);

        // Store result in dictionary for memoization
        remember[s] = ways;
        return ways;
    }

    // ########################
    // # Problem 4: WildcardBinary
    // ########################
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base case: no wildcards left
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Recursive step: replace * with 0 and 1
        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);
    }

    // ########################
    // # Problem 5: SolveMaze
    // ########################
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize path on first run
        if (currPath == null) currPath = new List<ValueTuple<int, int>>();

        // Add current position to path
        currPath.Add((x, y));

        // If we reached the end, add current path to results
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Explore all four directions
            var directions = new (int dx, int dy)[] { (1, 0), (0, 1), (-1, 0), (0, -1) };
            foreach (var (dx, dy) in directions)
            {
                int newX = x + dx;
                int newY = y + dy;
                if (maze.IsValidMove(currPath, newX, newY))
                {
                    SolveMaze(results, maze, newX, newY, currPath);
                }
            }
        }

        // Backtrack: remove current position from path before returning
        currPath.RemoveAt(currPath.Count - 1);
    }
}