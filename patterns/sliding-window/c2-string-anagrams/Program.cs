/*
String Anagrams (hard)#

Given a string and a pattern, find all anagrams of the pattern in the given string.

Every anagram is a permutation of a string. As we know, when we are not allowed to repeat characters while finding permutations of a string, we get N!N!N! permutations (or anagrams) of a string having NNN characters. For example, here are the six anagrams of the string “abc”:

    abc
    acb
    bac
    bca
    cab
    cba

Write a function to return a list of starting indices of the anagrams of the pattern in the given string.

Example 1:

Input: String="ppqp", Pattern="pq"
Output: [1, 2]
Explanation: The two anagrams of the pattern in the given string are "pq" and "qp".

Example 2:

Input: String="abbcabc", Pattern="abc"
Output: [2, 3, 4]
Explanation: The three anagrams of the pattern in the given string are "bca", "cab", and "abc".
*/

List<int> StringAnagrams_Optomized(string str, string pattern)
{
    List<int> matches = new();
    Dictionary<char, int> patternMap = new Dictionary<char, int>();
    HashSet<char> patternChars = new HashSet<char>(pattern);
    int matched= 0;
    //set the pattern map
    for (int i=0; i< pattern.Length; i++)
    {
        int count = patternMap.GetValueOrDefault(pattern[i]) + 1;
        patternMap[pattern[i]] = count;
    }

    for (int start = 0, end =0; end < str.Length; end++)
    {
        // if this char is part of the pattern, remove it
        if (patternChars.Contains(str[end]))
        {
            int count = patternMap.GetValueOrDefault(str[end]) - 1;
            if (count <= 0)
            {
                patternMap.Remove(str[end]);
                matched++;
            }
            else
            {
                patternMap[str[end]] = count;
            }
        }

        if (matched == patternChars.Count)
        {
            matches.Add(start);
        }

        // if we've found a window length that matches, check if this is an anagram
        if (end-start+1 == pattern.Length)
        {
            // move the start of the windows one position
            // this way we always have a window the size of the pattern
            if (patternChars.Contains(str[start]))
            {
                int count = patternMap.GetValueOrDefault(str[start]) + 1;
                patternMap[str[start]] = count;
                matched--;
            }
            start++;
        }
    }

    return matches;
}

List<int> StringAnagrams(string str, string pattern)
{
    List<int> matches = new();
    Dictionary<char, int> patternChars = new Dictionary<char, int>();
    Dictionary<char,int> foundChars = new();

    for (int i=0; i< pattern.Length; i++)
    {
        int count = patternChars.GetValueOrDefault(pattern[i]) + 1;
        patternChars[pattern[i]] = count;
    }

    for (int start = 0, end =0; end < str.Length; end++)
    {
        // if this char is part of the pattern, record it
        if (patternChars.ContainsKey(str[end]))
        {
            int count = foundChars.GetValueOrDefault(str[end]) +1;
            foundChars[str[end]] = count;
        }

        // if we've found a window length that matches, check if this is an anagram
        if (end-start+1 == pattern.Length)
        {
            if (foundChars.Count == pattern.Length)
            {
                // check the counts of the found chars
                bool match = true;
                foreach (KeyValuePair<char, int> kvp in patternChars)
                {
                    if (kvp.Value != foundChars[kvp.Key])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    matches.Add(start);
                }
            }

            // move the start of the windows one position
            // this way we always have a window the size of the pattern
            int count = foundChars[str[start]] - 1;
            if (count == 0)
            {
                foundChars.Remove(str[start]);
            }
            else
            {
                foundChars[str[start]] = count;
            }

            start++;
        }
    }

    return matches;
}

Console.WriteLine($"{String.Join(",", StringAnagrams("ppqp", "pq"))}");
Console.WriteLine($"{String.Join(",", StringAnagrams("abbcabc", "abc"))}");
