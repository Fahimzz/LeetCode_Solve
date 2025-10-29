public class Solution {
    public int SmallestNumber(int n) {
        return (1 << (32 - System.Numerics.BitOperations.LeadingZeroCount((uint)n))) - 1;
    }
}