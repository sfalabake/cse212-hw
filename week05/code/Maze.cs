// DO NOT MODIFY THIS FILE

public class Maze
{
    public int Width { get; }
    public int Height { get; }

    public readonly int[] Data;

    public Maze(int width, int height, int[] data)
    {
        this.Width = width;
        this.Height = height;
        this.Data = data;
    }

    // ########################
    // # Problem 5 Helpers
    // ########################

    // Check if the current position is the end
    public bool IsEnd(int x, int y)
    {
        return Data[y * Height + x] == 2;
    }

    // Check if a move is valid
    public bool IsValidMove(List<ValueTuple<int, int>> currPath, int x, int y)
    {
        // Out of bounds
        if (x < 0 || x >= Width || y < 0 || y >= Height) return false;
        // Wall
        if (Data[y * Height + x] == 0) return false;
        // Already visited
        if (currPath.Contains((x, y))) return false;

        return true;
    }
}