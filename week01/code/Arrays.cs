using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' 
    /// followed by multiples of 'number'.
    /// </summary>
    /// <param name="number">The base number to find multiples of.</param>
    /// <param name="length">The size of the resulting array.</param>
    /// <returns>Array of doubles that are the multiples of the supplied number.</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // STEP-BY-STEP PLAN:
        // 1. Initialize a new array of doubles with the specified 'length'.
        // 2. Create a loop that iterates from 0 up to 'length'.
        // 3. In each iteration, calculate the multiple by multiplying 'number' by (current index + 1).
        // 4. Store the calculated value into the current index of the array.
        // 5. Return the completed array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            // We use (i + 1) because multiples usually start at 1 * number
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// This function modifies the existing list in-place.
    /// </summary>
    /// <param name="data">The list of integers to rotate.</param>
    /// <param name="amount">The number of positions to rotate to the right.</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        // STEP-BY-STEP PLAN:
        // 1. Calculate the starting position of the slice to be moved (List length - amount).
        // 2. Extract the last 'amount' elements from the list using GetRange.
        // 3. Remove those same 'amount' elements from the end of the original list.
        // 4. Insert the extracted elements at the very beginning (index 0) of the list.
        
        // Handle case where list might be empty or amount is 0
        if (data.Count == 0 || amount <= 0) return;

        // Step 1 & 2: Get the elements that will be moved to the front
        int startCopyIndex = data.Count - amount;
        List<int> movedPart = data.GetRange(startCopyIndex, amount);

        // Step 3: Remove the elements from their original back position
        data.RemoveRange(startCopyIndex, amount);

        // Step 4: Insert the elements at the front
        data.InsertRange(0, movedPart);
    }
}
