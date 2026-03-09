public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of doubles with the size defined by the 'length' parameter.
        double[] results = new double[length];

        // Step 2: Use a loop to iterate through each index from 0 up to (length - 1).
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple. 
            // Since the first multiple is the number itself (number * 1), 
            // we multiply the 'number' by (i + 1).
            results[i] = number * (i + 1);
        }

        // Step 4: Return the populated array.
        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate the starting index of the segment that needs to be moved to the front.
        // This is found by subtracting the rotation amount from the total count of the list.
        int startingIndex = data.Count - amount;

        // Step 2: Use GetRange to extract the "tail" segment of the list starting from 
        // the calculated index to the end.
        List<int> movedSegment = data.GetRange(startingIndex, amount);

        // Step 3: Remove that same segment from its original position at the end of the list.
        data.RemoveRange(startingIndex, amount);

        // Step 4: Insert the extracted segment back into the list at index 0 (the front).
        data.InsertRange(0, movedSegment);
    }
}