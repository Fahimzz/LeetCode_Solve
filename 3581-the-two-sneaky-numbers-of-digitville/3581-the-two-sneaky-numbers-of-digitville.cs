public class Solution {
    public int[] GetSneakyNumbers(int[] nums) {
        int n = nums.Length - 2;

        double actualSum = 0;          
        double actualSquareSum = 0;    
        foreach (int x in nums) {
            actualSum += x;
            actualSquareSum += x * x;
        }

        double expectedSum = n * (n - 1) / 2.0;
        double expectedSquareSum = n * (n - 1) * (2 * n - 1) / 6.0;

        double S = actualSum - expectedSum;
        double Q = actualSquareSum - expectedSquareSum;

        double diff = Math.Sqrt(2 * Q - S * S);

        int x1 = (int)((S - diff) / 2);
        int x2 = (int)((S + diff) / 2);

        return new int[] { x1, x2 };
    }
}