public class Solution {
    public string SortVowels(string s) {
        List<char> vowels = new List<char>();
        foreach (char c in s) {
            if ("AEIOUaeiou".Contains(c)) {
                vowels.Add(c);
            }
        }

        vowels.Sort();
        int index = 0;
        char[] chars = s.ToCharArray();

        for (int i = 0; i < chars.Length; i++) {
            if ("AEIOUaeiou".Contains(chars[i])) {
                chars[i] = vowels[index++];
            }
        }

        return new string(chars);
    }
}