public class Solution {
    public int TriangleNumber(int[] nums) {
        Array.Sort(nums);
        int count = 0;
        int n = nums.Length;

        for (int i = n - 1; i >= 2; i--) {
            int left = 0, right = i - 1;

            while (left < right) {
                if (nums[left] + nums[right] > nums[i]) {
                    count += right - left;
                    right--;
                } else {
                    left++;
                }
            }
        }
        return count;
    }
}