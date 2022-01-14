/*
Problem Statement#

Given an array of characters where each character represents a fruit tree, you are given two baskets, and your goal is to put maximum number of fruits in each basket. The only restriction is that each basket can have only one type of fruit.

You can start with any tree, but you can’t skip a tree once you have started. You will pick one fruit from each tree until you cannot, i.e., you will stop when you have to pick from a third fruit type.

Write a function to return the maximum number of fruits in both baskets.

Example 1:

Input: Fruit=['A', 'B', 'C', 'A', 'C']
Output: 3
Explanation: We can put 2 'C' in one basket and one 'A' in the other from the subarray ['C', 'A', 'C']

Example 2:

Input: Fruit=['A', 'B', 'C', 'B', 'B', 'C']
Output: 5
Explanation: We can put 3 'B' in one basket and two 'C' in the other basket. 
This can be done if we start with the second letter: ['B', 'C', 'B', 'B', 'C']
*/

// See https://aka.ms/new-console-template for more information

int MaxFruitsInBAsket(char[] fruits)
{
    //validate inputs
    // TODO

    // baskets
    Dictionary<char, int> baskets = new Dictionary<char, int>();
    int max = 0;
    for (int start = 0, end = 0; end < fruits.Length; end++)
    {
        // add the fruit to the baskets
        int fruitCount = baskets.GetValueOrDefault(fruits[end]);
        fruitCount++;
        baskets[fruits[end]] = fruitCount;

        while (baskets.Count >2)
        {
            // remove the first fruit
            fruitCount = baskets[fruits[start]];
            fruitCount--;
            if (fruitCount == 0)
            {
                baskets.Remove(fruits[start]);
            }
            else
            {
                baskets[fruits[start]] = fruitCount;
            }

            // move the end of the window 
            start++;
        }

        max = Math.Max(max, end- start +1);
    }
    return max;
}

Console.WriteLine($"output {MaxFruitsInBAsket(new [] {'A', 'B', 'C', 'A', 'C' }) }");

Console.WriteLine($"output {MaxFruitsInBAsket(new [] {'A', 'B', 'C', 'B', 'B', 'C' }) }");

Console.WriteLine($"output {MaxFruitsInBAsket(new [] {'A' }) }");

Console.WriteLine($"output {MaxFruitsInBAsket(new [] {'A',  'B'}) }");
