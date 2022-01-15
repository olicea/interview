/*
Pair with smaller sum 

Problem Statement#

Given an array of sorted numbers and a target sum, find a pair in the array whose sum is equal to the given target.

Write a function to return the indices of the two numbers (i.e. the pair) such that they add up to the given target.

Example 1:

Input: [1, 2, 3, 4, 6], target=6
Output: [1, 3]
Explanation: The numbers at index 1 and 3 add up to 6: 2+4=6

Example 2:

Input: [2, 5, 9, 11], target=11
Output: [0, 2]
Explanation: The numbers at index 0 and 2 add up to 11: 2+9=11

*/

static int[] PairWithSmallerSum(int[] arr, int target)
{
    int l =0;
    int r=arr.Length-1;

    // while the pointer haven't crossed
    // and we are not at the target
    while (l<r &&
        arr[l] + arr[r] != target)
    {
        int sum = arr[l] + arr[r];
        if (sum < target) l++;
        if (sum > target) r--;
    }
    // return the solution if we found one, or an empty array if there is no solution
    return l<r ? new int[] {l, r} : Array.Empty<int>(); 
}

Console.WriteLine($"{string.Join(",", PairWithSmallerSum(new[] {1, 2, 3, 4, 6}, 6))}");
Console.WriteLine($"{string.Join(",", PairWithSmallerSum(new[] {2, 5, 9, 11}, 11))}");