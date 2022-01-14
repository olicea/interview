/*
Longest Substring with Distinct Characters

Problem Statement#

Given a string, find the length of the longest substring, which has all distinct characters.

Example 1:

Input: String="aabccbb"
Output: 3
Explanation: The longest substring with distinct characters is "abc".

Example 2:

Input: String="abbbb"
Output: 2
Explanation: The longest substring with distinct characters is "ab".

Example 3:

Input: String="abccde"
Output: 3
Explanation: Longest substrings with distinct characters are "abc" & "cde".
*/

long LongestSubString(string str)
{
    int max =0;
    //keep track of the end of each char
    Dictionary<char, int> chars = new Dictionary<char, int>();

    //move a window to count the characters
    for (int start=0, end=0; end < str.Length && start < str.Length; end++)
    {
        // add the current char to the hash
        int count = chars.GetValueOrDefault(str[end]);
        count++;
        chars[str[end]] = count;

        //move the window while the conditions remain
        while (chars.GetValueOrDefault(str[end]) > 1)
        {
            count = chars[str[start]];
            count --;
            chars[str[start]] = count;

            start++;
        }

        max =  Math.Max(max, end-start +1);
    }

    return max;
}

int LongestSubString2(string str)
{
    if (String.IsNullOrEmpty(str))
    {
        throw new ArgumentException(nameof(str));
    }
    int max =0;

    // move the current chat, keep track of the index of the last time we saw a characrter
    // when we see a repeated char, move the start os the substring

    Dictionary<char, int> chars = new Dictionary<char, int>();
    for (int start = 0, end = 0; end < str.Length; end++)
    {
        // if the character was seen before,
        // update the index on the hash
        if (chars.ContainsKey(str[end]))
        {
            start = Math.Max(max, chars[str[end]] + 1);
        }

        //update the index for the char at the end
        chars[str[end]] = end;

        // keep track of the max length so far
        max = Math.Max(max, end-start+1);
    }

    return max;
}



Console.WriteLine($"{LongestSubString2("aabccbb")}");
Console.WriteLine($"{LongestSubString2("abbbb")}");
Console.WriteLine($"{LongestSubString2("abccde")}");
