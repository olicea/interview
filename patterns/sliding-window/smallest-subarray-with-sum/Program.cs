/*
Problem Statement#

Given an array of positive numbers and a positive number ‘S,’ find the length of the smallest contiguous subarray whose sum is greater than or equal to ‘S’. Return 0 if no such subarray exists.

Example 1:

Input: [2, 1, 5, 2, 3, 2], S=7 
Output: 2
Explanation: The smallest subarray with a sum greater than or equal to '7' is [5, 2].

Example 2:

Input: [2, 1, 5, 2, 8], S=7 
Output: 1
Explanation: The smallest subarray with a sum greater than or equal to '7' is [8].

Example 3:

Input: [3, 4, 1, 1, 6], S=8 
Output: 3
Explanation: Smallest subarrays with a sum greater than or equal to '8' are [3, 4, 1] 
or [1, 1, 6].
*/

int SmallestSubArrayWithSum(int [] array, int s)
{
    //validate inputs
    //TODO

    // init variables
    int smallestArrayLength = int.MaxValue;

    // slide start array from start to end
    int startArray = 0;
    long sum = 0;
    for (int endArray = 0; endArray < array.Length; endArray++)
    {
        //add current element to sum
        sum += array[endArray];

        //once we've found the sum we need, check if the length is smaller thant hte previous one
        while (sum >= s)
        {
            // and the length of subarray is smaller than the previously know one, store it
            if (endArray - startArray < smallestArrayLength)
            {
                smallestArrayLength = endArray - startArray;
            }

            // subtract the element going out
            sum -= array[startArray]; 

            // move the start
            startArray++;
        }
    }

    // if we did not find a proper subarray, return -1 (Error)
    // optionally we could throw
    return smallestArrayLength == int.MaxValue ? -1 : smallestArrayLength + 1;
}


Console.WriteLine($"smallest {SmallestSubArrayWithSum(new []{2, 1, 5, 2, 3, 2}, 7)}");

Console.WriteLine($"smallest {SmallestSubArrayWithSum(new []{2, 1, 5, 2, 8}, 7)}");

Console.WriteLine($"smallest {SmallestSubArrayWithSum(new []{3, 4, 1, 1, 6}, 8)}");
