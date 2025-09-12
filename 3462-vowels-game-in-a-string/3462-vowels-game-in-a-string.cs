public class Solution {
    public bool DoesAliceWin(string s) {
        for (int i = 0; i < s.Length; i++)
            if ((0x104111 >> (s[i] - 97) & 1) != 0)
                return true;
        return false;
    }
}