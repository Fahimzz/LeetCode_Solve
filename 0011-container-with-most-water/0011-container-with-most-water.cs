public class Solution {
    public int MaxArea(int[] height) {
        if(height.Length<1)
{
    return 0;
}
int left = 0;
int right = height.Length - 1;
int maxArea = 0;
while (left < right)
{
    int width = right - left;
    int minHeight = Math.Min(height[left], height[right]);
    int area = width * minHeight;
    maxArea = Math.Max(maxArea, area);
    if (height[left] < height[right])
    {
        left++;
    }
    else
    {
        right--;
    }
}
return maxArea;
    }
}