public class Solution {
  public IList<string> RemoveAnagrams(string[] words)
{
    List<string> res = new List<string>();
    res.Add(words[0]);  // result array
    int n = words.Length;

    for (int i = 1; i < n; i++)
    {
        if (!Compare(words[i], words[i - 1]))
        {
            res.Add(words[i]);
        }
    }
    return res;
}

// determine if two words are anagrams
private bool Compare(string word1, string word2)
{
    int[] freq = new int[26];
    foreach (char ch in word1)
    {
        freq[ch - 'a']++;
    }
    foreach (char ch in word2)
    {
        freq[ch - 'a']--;
    }
    foreach (int x in freq)
    {
        if (x != 0)
        {
            return false;
        }
    }
    return true;
}
}