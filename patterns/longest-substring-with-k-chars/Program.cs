/*
Problem Statement#

Given a string, find the length of the longest substring in it with no more than K distinct characters.

Example 1:

Input: String="araaci", K=2
Output: 4
Explanation: The longest substring with no more than '2' distinct characters is "araa".

Example 2:

Input: String="araaci", K=1
Output: 2
Explanation: The longest substring with no more than '1' distinct characters is "aa".

Example 3:

Input: String="cbbebi", K=3
Output: 5
Explanation: The longest substrings with no more than '3' distinct characters are "cbbeb" & "bbebi".

Example 4:

Input: String="cbbebi", K=10
Output: 6
Explanation: The longest substring with no more than '10' distinct characters is "cbbebi".
*/

int LongestSubArray(string str, int k)
{
    //validate inputs
    if (string.IsNullOrEmpty(str) || k <0)
    {
        throw new System.ArgumentException();
    }

    //init
    int maxLength =0;

    // slide a window and keep track of used chars
    Dictionary<char, int> usedChars = new Dictionary<char, int>();
    for (int start =0, end =0; end < str.Length; end++)
    {
        // keep track of char
        int charCount = usedChars.GetValueOrDefault(str[end]);
        charCount ++;
        usedChars[str[end]] = charCount;
        
        // if we have seen enough different characters then check if the array is 
        // and move the start of the subarray
        while (usedChars.Count > k)
        {
            // remove the char left  out at the start
            charCount = usedChars[str[start]];
            charCount--;
            if (charCount ==0)
            {
                usedChars.Remove(str[start]);
            }
            else
            {
                usedChars[str[end]] = charCount;
            }
            //move the start of the subarray
            start++;
        }

        if (end-start > maxLength)
        {
            maxLength = end-start;
        }
    }

    // add 1 to the index diff since indexes are zero based, and length is one-based
    return maxLength + 1;
}


Console.WriteLine($"output {LongestSubArray("araaci", 2)}");

Console.WriteLine($"output {LongestSubArray("araaci", 1)}");

Console.WriteLine($"output {LongestSubArray("cbbebi", 3)}");

Console.WriteLine($"output {LongestSubArray("cbbebi", 10)}");