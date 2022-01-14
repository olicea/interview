/*
Longest Subarray with Ones after Replacement (hard)

Problem Statement#

Given an array containing 0s and 1s, if you are allowed to replace no more than ‘k’ 0s with 1s, find the length of the longest contiguous subarray having all 1s.

Example 1:

Input: Array=[0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1], k=2
Output: 6
Explanation: Replace the '0' at index 5 and 8 to have the longest contiguous subarray of 1s having length 6.

Example 2:

Input: Array=[0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1], k=3
Output: 9
Explanation: Replace the '0' at index 6, 9, and 10 to have the longest contiguous subarray of 1s having length 9.

*/
int LongestSubArray(int[] arr, int k)
{
    int max= 0;
    int maxOnes = 0;

    for (int start=0, end=0; end < arr.Length; end ++)
    {
        // keep track of the number of ones on this window
        if (arr[end] ==1)
        {
            maxOnes++;
        }

        //if we can't replace at most K 0 on this wondow, shrink the window
        if (end - start + 1 - maxOnes > k)
        {
            // id the element at the left is a 1, adjust the count of ones
            if (arr[start] == 1)
            {
                maxOnes--;
            }
            // move the start of the window
            start ++;
        }

        // keep track of the longest window
        max = Math.Max(max, end-start+1);
    }

    return max;
}


Console.WriteLine($"{LongestSubArray(new[] {0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1}, 2)}");
Console.WriteLine($"{LongestSubArray(new[] {0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1}, 3)}");
