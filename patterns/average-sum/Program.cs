﻿class Program
{
    public static void Main()
    {
        int[] array = new[] {1, 3, 2, 6, -1, 4, 1, 8, 2};
        int k=5;

        double[] averages = AverageOFArrayReuse(array, k);
        Console.WriteLine($"average {string.Join(",", averages)}");
    }

    private static double[] AverageOFArrayReuse(int[] array, int k)
    {
        // the number of sums is array.length - K
        double[] averages = new double[array.Length - k + 1];

        // calculate sum of first K elements
        int sum =0;
        for (int j=0; j<k; j++)
        {
            sum+= array[j];
        }
        averages[0] = (double) sum/k;

        for (int i=1; i<averages.Length; i++)
        {
            //subtract old element 
            sum -= array[i-1];
            sum += array[i+k-1];

            // store the average of the sub array, force a cast
            averages[i] = (double) sum/k;
        }
        return averages;
    }
    
    private static double[] AverageOFArray(int[] array, int k)
    {
        // the number of sums is array.length - K
        double[] averages = new double[array.Length - k + 1];
        for (int i=0; i<averages.Length; i++)
        {
            // calculate teh sum of the sub array
            int sum =0;
            for (int j=i; j<k+i; j++)
            {
                sum+= array[j];
            }
            // store the average of the sub array, force a cast
            averages[i] = (double) sum/k;
        }
        return averages;
    }
}