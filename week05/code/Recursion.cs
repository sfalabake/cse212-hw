using System.Collections;
using System.Diagnostics;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: if n <= 0, return 0
        if (n <= 0)
            return 0;

        // Recursive case: n^2 + sum of squares of 1..(n-1)
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  
    /// Each letter is unique.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if word reached target size, add to results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: try each letter not yet used in word
        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];
            // Avoid using the same letter twice in this word
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the number of ways to climb 's' stairs using 1,2,3 steps.
    /// Uses memoization to avoid recomputation.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize memoization dictionary if null
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Return cached value if already computed
        if (remember.ContainsKey(s))
            return remember[s];

        // Base cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        // Recursive case with memoization
        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        // Store result for future reference
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Generate all possible binary strings matching a pattern
    /// containing 1, 0, and wildcard *.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Base case: no wildcard remaining, add pattern as result
        int starIndex = pattern.IndexOf('*');
        if (starIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        // Recursive case: replace * with '0' and '1'
        WildcardBinary(pattern.Substring(0, starIndex) + '0' + pattern.Substring(starIndex + 1), results);
        WildcardBinary(pattern.Substring(0, starIndex) + '1' + pattern.Substring(starIndex + 1), results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Solve a maze recursively: insert all paths from (0,0) to end.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // Add current position to path
        currPath.Add((x, y));

        // If we reached the end, add path to results
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1); // Backtrack
            return;
        }

        // Explore all four directions (up, down, left, right)
        var directions = new (int dx, int dy)[] { (1, 0), (0, 1), (-1, 0), (0, -1) };
        foreach (var (dx, dy) in directions)
        {
            int newX = x + dx;
            int newY = y + dy;
            if (maze.IsValidMove(newX, newY, currPath))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }

        // Backtrack: remove current position before returning
        currPath.RemoveAt(currPath.Count - 1);
    }
}