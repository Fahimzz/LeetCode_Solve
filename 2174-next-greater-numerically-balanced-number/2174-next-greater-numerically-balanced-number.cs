public class Solution {
    public int NextBeautifulNumber(int n) {
        List<int> list = new List<int>();
        Generate(0, new int[10], list);
        list.Sort();
        foreach (int num in list) {
            if (num > n) return num;
        }
        return -1;
    }

    private void Generate(long num, int[] count, List<int> list) {
        if (num > 0 && IsBeautiful(count)) list.Add((int)num);
        if (num > 1224444) return;

        for (int d = 1; d <= 7; d++) {
            if (count[d] < d) {
                count[d]++;
                Generate(num * 10 + d, count, list);
                count[d]--;
            }
        }
    }

    private bool IsBeautiful(int[] count) {
        for (int d = 1; d <= 7; d++)
            if (count[d] != 0 && count[d] != d) return false;
        return true;
    }
}