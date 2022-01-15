/*
Smallest Window containing Substring (hard)#

Given a string and a pattern, find the smallest substring in the given string which has all the characters of the given pattern.

Example 1:

Input: String="aabdec", Pattern="abc"
Output: "abdec"
Explanation: The smallest substring having all characters of the pattern is "abdec"

Example 2:

Input: String="abdbca", Pattern="abc"
Output: "bca"
Explanation: The smallest substring having all characters of the pattern is "bca".

Example 3:

Input: String="adcad", Pattern="abc"
Output: ""
Explanation: No substring in the given string has all characters of the pattern.
*/

string SmallestWindow(string str, string pattern)
{
    if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(pattern))
    {
        throw new ArgumentException();
    }

    Dictionary<char, int> patternMap = new();
    for (int i=0; i<pattern.Length; i++)
    {
        int count = patternMap.GetValueOrDefault(pattern[i]) + 1;
        patternMap[pattern[i]] = count;
    }
    
    int matched = 0;
    int minLength = int.MaxValue;
    int minStart = 0;
    int minEnd = 0;
    for (int end = 0, start= 0; end < str.Length; end++)
    {
        if(patternMap.ContainsKey(str[end]))
        {
            int count = patternMap[str[end]] - 1;
            patternMap[str[end]] = count;
            if (count >=0)
            {
                matched++;
            }
        }

        // shrink the window if we can
        while (matched == pattern.Length)
        {
            if (end-start+1 < minLength)
            {
                minLength = end-start+1;
                minStart = start;
                minEnd = end;
            }

            if (patternMap.ContainsKey(str[start]))
            {
                // put the char back in the map
                int count = patternMap[str[start]];
                if (count == 0)
                {
                    matched --;
                }
                
                patternMap[str[start]] = count + 1;
            }
            start++;
        }
    }
    return minLength > str.Length ? 
        string.Empty :
        str.Substring(minStart, minEnd-minStart+1);
}

Console.WriteLine($"{SmallestWindow("aabdec", "abc")}");
Console.WriteLine($"{SmallestWindow("abdbca", "abc")}");
Console.WriteLine($"{SmallestWindow("adcad", "abc")}");