public class Solution {
    public int CountSquares(int[][] matrix) {
         int count = 0;
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int[][] dp = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            dp[i] = new int[cols];
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i][j] == 1)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i][j] = 1;
                    }
                    else
                    {
                        dp[i][j] = Math.Min(dp[i - 1][j], Math.Min(dp[i][j - 1], dp[i - 1][j - 1])) + 1;
                    }
                    count += dp[i][j];
                }
            }
        }

        return count;
    }
}