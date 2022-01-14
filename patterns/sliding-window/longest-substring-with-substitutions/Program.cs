/*
Longest Substring with Same Letters after Replacement (hard)

Problem Statement#

Given a string with lowercase letters only, if you are allowed to replace no more than k letters with any letter, find the length of the longest substring having the same letters after replacement.

Example 1:

Input: String="aabccbb", k=2
Output: 5
Explanation: Replace the two 'c' with 'b' to have the longest repeating substring "bbbbb".

Example 2:

Input: String="abbcb", k=1
Output: 4
Explanation: Replace the 'c' with 'b' to have the longest repeating substring "bbbb".

Example 3:

Input: String="abccde", k=1
Output: 3
Explanation: Replace the 'b' or 'd' with 'c' to have the longest repeating substring "ccc".
*/

int LongestSubStringWithSubs(string str, int k)
{
    if (string.IsNullOrEmpty(str))
    {
        throw new ArgumentException(nameof(str));
    }

    if (k<0)
    {
        throw new ArgumentException(nameof(k));
    }

    // most frequent Letter
    int max = 0;
    int mostFrequent = 0;

    // move a sliding window to count the freqency of chars
    // it the most frequent + k > than the previous max, then this is the new max
    Dictionary<char, int> chars = new(); 

    for (int start = 0, end = 0; end < str.Length; end++)
    {
        // count the current character
        int charF = chars.GetValueOrDefault(str[end]);
        charF++;
        chars[str[end]] = charF;

        //check if this is now the most frequent letter
        mostFrequent = Math.Max(mostFrequent, charF);

        //if we can't substitute at most K letters on this window
        // the move the start
        if (end - start + 1 - mostFrequent > k)
        {
            //remove char
            charF = chars[str[start]];
            charF--;
            chars[str[start]]=charF;

            // advance the window
            start ++;
        }

        //keep track of the longest window
        max = Math.Max(max, end-start + 1);
    }

    return max ;
}


Console.WriteLine($"{LongestSubStringWithSubs("aabccbb", 2)}");
Console.WriteLine($"{LongestSubStringWithSubs("abbcb", 1)}");
Console.WriteLine($"{LongestSubStringWithSubs("abccde", 1)}");