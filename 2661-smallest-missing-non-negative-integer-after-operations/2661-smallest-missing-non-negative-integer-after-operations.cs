public class Solution {
    public int FindSmallestInteger(int[] nums, int value) {
        var count = new Dictionary<int, int>();
        foreach (var x in nums) {
            int r = ((x % value) + value) % value;
            if (!count.ContainsKey(r)) count[r] = 0;
            count[r]++;
        }
        int mex = 0;
        while (count.ContainsKey(mex % value) && count[mex % value] > 0) {
            count[mex % value]--;
            mex++;
        }
        return mex;
    }
};