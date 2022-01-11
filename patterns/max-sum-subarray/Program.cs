using System;
// See https://aka.ms/new-console-template for more information

long MaxSumSubArray(int[] array, int k)
{
    
    if (array == null)
    {
        throw new ArgumentNullException("array is null");
    }

    if (array.Length ==0)
    {
        throw new ArgumentException("array is empty");
    }

    if (k <=0)
    {
        throw new ArgumentException("k should be positive");
    }

    //check for valid inputs 
    if (array.Length < k)
    {
        throw new ArgumentException("k should be at least as big as array");
    }

    long max = 0;
    long sum =0;
    //subArrayStart is start of subarray, subArrayEnd is end of subarray
    for (int subArrayStart=-k, subArrayEnd=0; subArrayEnd<array.Length; subArrayStart++, subArrayEnd++)
    {
        //add the current number
        sum += array[subArrayEnd];

        // if we have added all numbers on a window
        if (subArrayEnd >= k-1)
        {
            // substract the number outside of the window
            if (subArrayStart>=0)
            {   
                sum -= array[subArrayStart];
            }

            // if we have found a new max then store it
            if (sum > max)
            {
                max=sum;
            }
        }
    }

    return max;
}

Console.WriteLine($"max {MaxSumSubArray(new[] {2, 1, 5, 1, 3, 2}, 3)}");

Console.WriteLine($"max {MaxSumSubArray(new[] {2, 3, 4, 1, 5}, 2)}");
//empty array
try 
{
    MaxSumSubArray(new int[0] {}, 1);
}
catch (ArgumentException) {}

//null array
try 
{
    MaxSumSubArray(null, 1);
}
catch (ArgumentNullException) {}

//k is bigger than array.Length array
try 
{
    MaxSumSubArray(new[] {2, 3, 4, 1, 5}, 100);
}
catch (ArgumentException) {}

//k is negative
try 
{
    MaxSumSubArray(new[] {2, 3, 4, 1, 5}, -1);
}
catch (ArgumentException) {}