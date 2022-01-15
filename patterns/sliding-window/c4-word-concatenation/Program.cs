/*
Words Concatenation (hard)#

Given a string and a list of words, find all the starting indices of substrings in the given string that are a concatenation of all the given words exactly once without any overlapping of words. It is given that all words are of the same length.

Example 1:

Input: String="catfoxcat", Words=["cat", "fox"]
Output: [0, 3]
Explanation: The two substring containing both the words are "catfox" & "foxcat".

Example 2:

Input: String="catcatfoxfox", Words=["cat", "fox"]
Output: [3]
Explanation: The only substring containing both the words is "catfox".
*/

List<int> WordConcatenations(string str, string[] words)
{
    if (String.IsNullOrEmpty(str) || 
        words ==null || words.Length == 0)
    {
        throw new ArgumentException();
    }

    // create a map of the words
    Dictionary<string, int> wordMap = new();
    List<int> indexes = new();

    // create a map of the words and their occurrences
    int wordLength = words[0].Length;
    for (int i=0; i < words.Length; i++)
    {
        int count = wordMap.GetValueOrDefault(words[i]) + 1;
        wordMap[words[i]] = count;
        if (words[i].Length != wordLength)
        {
            throw new ArgumentException("one word's length does not match");
        }
    }

    //keep track of matched words
    int matched = 0;
    for (int start =0, end=0; end < str.Length; end += wordLength)
    {
        string word = str.Substring(end, wordLength);
        // if we find a word, then keep track of it
        if (wordMap.ContainsKey(word))
        {
            int count = wordMap[word] -1;
            if (count >= 0)
            {
                matched++;
            }
            wordMap[word] = count;
        }

        // we found a match
        if (matched == words.Length)
        {
            indexes.Add(start);
        }

        // we need to shrink the window it needs to be at least the same size as the word list
        if ((end - start)/wordLength + 1 >= words.Length)
        {
            string wordStart = str.Substring(start, wordLength);

            // the word leaving the window is in the list, keep track of it
            if (wordMap.ContainsKey(wordStart))
            {
                int count = wordMap[wordStart];
                if (count == 0)
                {
                    matched--;
                }
                wordMap[wordStart] = count + 1;
            }
            start += wordLength;
        }
    }

    return indexes;
}

Console.WriteLine($"{string.Join(",", WordConcatenations("catfoxcat", new string[] {"cat", "fox"}))}");
Console.WriteLine($"{string.Join(",", WordConcatenations("catcatfoxfox", new string[] {"cat", "fox"}))}");
Console.WriteLine($"{string.Join(",", WordConcatenations("ab", new string[] {"b", "a"}))}");
Console.WriteLine($"{string.Join(",", WordConcatenations("catfox", new string[] {"pie", "fox"}))}");
