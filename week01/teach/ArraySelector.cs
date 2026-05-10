using System;
using System.Collections.Generic;

public static class ArraySelector
{
    /// <summary>
    /// Entry point for the ArraySelector activity.
    /// </summary>
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); 
        // Expected output: <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    /// <summary>
    /// Combines two arrays into one based on a selector array.
    /// </summary>
    /// <param name="list1">The first source array.</param>
    /// <param name="list2">The second source array.</param>
    /// <param name="select">Array containing 1s and 2s to guide selection.</param>
    /// <returns>A new array with the combined elements.</returns>
    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        // 1. Create the destination array with the same size as the selector
        int[] result = new int[select.Length];

        // 2. Initialize tracking indexes for both source lists
        int index1 = 0;
        int index2 = 0;

        // 3. Loop through the selector array to build the result
        for (int i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
            {
                // If selector is 1, take from list1 and increment its index
                result[i] = list1[index1];
                index1++;
            }
            else
            {
                // If selector is 2, take from list2 and increment its index
                result[i] = list2[index2];
                index2++;
            }
        }

        return result;
    }
}