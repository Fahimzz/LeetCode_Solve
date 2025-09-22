public class Solution {
    public int MaxFrequencyElements(int[] nums) {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        int frequency = 0, count = 0;

        foreach (int num in nums) {
            if (!freq.ContainsKey(num)) {
                freq[num] = 0;
            }
            freq[num]++;
        }

        foreach (var pair in freq) {
            if (pair.Value == frequency) {
                count++;
            } else if (pair.Value > frequency) {
                frequency = pair.Value;
                count = 1;
            }
        }

        return frequency * count;
    }
}