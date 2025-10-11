public class Solution {
    public long MaximumTotalDamage(int[] power) {
        var freq = new Dictionary<int, long>();
        foreach (var p in power) {
            if (!freq.ContainsKey(p)) freq[p] = 0;
            freq[p]++;
        }
        var keys = freq.Keys.ToList();
        keys.Sort();
        int n = keys.Count;
        long[] dp = new long[n];
        dp[0] = freq[keys[0]] * keys[0];
        for (int i = 1; i < n; i++) {
            long take = freq[keys[i]] * keys[i];
            int l = 0, r = i - 1, ans = -1;
            while (l <= r) {
                int mid = (l + r) / 2;
                if (keys[mid] <= keys[i] - 3) { ans = mid; l = mid + 1; }
                else r = mid - 1;
            }
            if (ans >= 0) take += dp[ans];
            dp[i] = Math.Max(dp[i - 1], take);
        }
        return dp[n - 1];
    }
}