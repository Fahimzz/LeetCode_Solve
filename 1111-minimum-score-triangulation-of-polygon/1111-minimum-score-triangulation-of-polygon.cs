public class Solution {
    public int MinScoreTriangulation(int[] values) {
        int n = values.Length;
        int[,] dp = new int[n, n];
        
        for (int len = 2; len < n; len++) {
            for (int i = 0; i + len < n; i++) {
                int j = i + len;
                dp[i, j] = int.MaxValue;
                for (int k = i + 1; k < j; k++) {
                    int cost = values[i] * values[k] * values[j]
                               + dp[i, k] + dp[k, j];
                    dp[i, j] = Math.Min(dp[i, j], cost);
                }
            }
        }
        
        return dp[0, n - 1];
    }
}