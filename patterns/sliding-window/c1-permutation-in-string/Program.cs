/*
Problem Challenge 1

Permutation in a String (hard)#

Given a string and a pattern, find out if the string contains any permutation of the pattern.

Permutation is defined as the re-arranging of the characters of the string. For example, “abc” has the following six permutations:

    abc
    acb
    bac
    bca
    cab
    cba

If a string has ‘n’ distinct characters, it will have n!n!n! permutations.

Example 1:

Input: String="oidbcaf", Pattern="abc"
Output: true
Explanation: The string contains "bca" which is a permutation of the given pattern.

Example 2:

Input: String="odicf", Pattern="dc"
Output: false
Explanation: No permutation of the pattern is present in the given string as a substring.

Example 3:

Input: String="bcdxabcdy", Pattern="bcdyabcdx"
Output: true
Explanation: Both the string and the pattern are a permutation of each other.

Example 4:

Input: String="aaacb", Pattern="abc"
Output: true
Explanation: The string contains "acb" which is a permutation of the given pattern.

*/

bool ContainsPermutation(string str, string pattern)
{
    if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(pattern))
    {
        throw new ArgumentException();
    }

    // walk the string, keep track of the chars we see
    // if the window contains all the chard in the pattern we are good

    Dictionary<char,int> foundChars = new();
    Dictionary<char,int> patterChars = new();

    for (int i =0; i<pattern.Length; i++)
    {            
        int pCount = patterChars.GetValueOrDefault(pattern[i]) + 1;
        patterChars[pattern[i]] = pCount;
    }

    int count =0;

    for (int end=0, start=0; end<str.Length; end++)
    {
        // if the char is part of the pattern count it
        if (patterChars.ContainsKey(str[end]))
        {
            int charCount = foundChars.GetValueOrDefault(str[end]);
            charCount++;
            foundChars[str[end]] = charCount;
            count++;
        }

        //if the window size is the same as the pattern 
        if (end-start+1 >= pattern.Length)
        {
            if (pattern.Length == count)
            {
                // if we have all the letters on the window check that they all match
                bool alllMatches =true;
                foreach (KeyValuePair<char, int> kvp in patterChars)
                {
                    if (kvp.Value != foundChars[kvp.Key])
                    {
                        alllMatches = false;
                        break;
                    }
                }
                if (alllMatches) return true;
            }

            // substract the chat (if is part of the pattern)
            if (patterChars.ContainsKey(str[start]))
            {
                int charCount = foundChars[str[start]];
                charCount--;
                count--;
                if (charCount ==0)
                {
                    foundChars.Remove(str[start]);
                }
                else
                {
                    foundChars[str[start]] = charCount;
                }
            }

            start++;
        }
        // any char not part of the pattern is ignored

    }

    // we did not find a substring
    return false;
}

Console.WriteLine($"{ContainsPermutation("oidbcaf", "abc")}");
Console.WriteLine($"{ContainsPermutation("odicf", "dc")}");
Console.WriteLine($"{ContainsPermutation("bcdxabcdy", "bcdyabcdx")}");
Console.WriteLine($"{ContainsPermutation("aaacb", "abc")}");
Console.WriteLine($"{ContainsPermutation("aab", "bba")}");
