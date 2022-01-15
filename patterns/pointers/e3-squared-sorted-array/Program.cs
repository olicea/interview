/*
Squaring a Sorted Array (easy)

Problem Statement#

Given a sorted array, create a new array containing squares of all the numbers of the input array in the sorted order.

Example 1:

Input: [-2, -1, 0, 2, 3]
Output: [0, 1, 4, 4, 9]

Example 2:

Input: [-3, -1, 0, 1, 2]
Output: [0, 1, 1, 4, 9]
*/
static int[] SquaredArray(int[] arr)
{
    int[] sqr = new int[arr.Length];
    int l=0;
    int r=arr.Length - 1;
    // the pointer will start at the end
    int i=arr.Length -1;
    while (l<r)
    {
        int lsqr = arr[l]*arr[l];
        int rsqr = arr[r]*arr[r];

        if (lsqr > rsqr)
        {
            sqr[i--] = lsqr;
            sqr[i--] = rsqr;
        }
        else
        {
            sqr[i--] = rsqr;
            sqr[i--] = lsqr;
        }
        l++;
        r--;
    }
    return sqr;
}

Console.WriteLine($"{string.Join(",", SquaredArray(new int[] {-2, -1, 0, 2, 3}))}");
Console.WriteLine($"{string.Join(",", SquaredArray(new int[] {-3, -1, 0, 1, 2}))}");