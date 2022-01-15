/*
Remove Duplicates (easy)

Problem Statement#

Given an array of sorted numbers, remove all duplicates from it. You should not use any extra space; after removing the duplicates in-place return the length of the subarray that has no duplicate in it.

Example 1:

Input: [2, 3, 3, 3, 6, 9, 9]
Output: 4
Explanation: The first four elements after removing the duplicates will be [2, 3, 6, 9].

Example 2:

Input: [2, 2, 2, 11]
Output: 2
Explanation: The first two elements after removing the duplicates will be [2, 11].
*/

static int RemoveDuplicates(int[] arr)
{
    int length = 0;
    for (int i=0; i<arr.Length; i++)
    {
        // count the character, if it is the first one, or it is different from the previous one
        if (i==0 || arr[i] != arr[i-1]) length++;
    }

    return length;
}

static int RemoveDuplicatesTwoLoops(int[] arr)
{
    int length = 0;
    for (int i=0; i<arr.Length; i++)
    {
        // count the current character
        length++;

        // advance all the characters that are the same 
        while (i+1 < arr.Length && arr[i] == arr[i+1])
        {
            i++;
        }
    }

    return length;
}

Console.WriteLine($"{RemoveDuplicates(new [] {2, 3, 3, 3, 6, 9, 9})}");
Console.WriteLine($"{RemoveDuplicates(new [] {2, 2, 2, 11})}");