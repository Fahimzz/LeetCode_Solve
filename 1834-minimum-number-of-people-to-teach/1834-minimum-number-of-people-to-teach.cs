public class Solution {
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships) {
        int m = languages.Length;
        int blocks = (n + 63) / 64; 
        ulong[][] masks = new ulong[m + 1][];
        for (int i = 1; i <= m; i++) {
            masks[i] = new ulong[blocks];
            foreach (int lang in languages[i-1]) {
                int idx = (lang-1) / 64;
                int bit = (lang-1) % 64;
                masks[i][idx] |= (1UL << bit);
            }
        }

        var candidates = new HashSet<int>();
        foreach (var f in friendships) {
            int u = f[0], v = f[1];
            bool canTalk = false;
            for (int b = 0; b < blocks; b++) {
                if ((masks[u][b] & masks[v][b]) != 0) { canTalk = true; break; }
            }
            if (!canTalk) { candidates.Add(u); candidates.Add(v); }
        }

        if (candidates.Count == 0) return 0;

        int[] count = new int[n+1];
        foreach (int u in candidates) {
            for (int lang = 1; lang <= n; lang++) {
                int idx = (lang-1) / 64;
                int bit = (lang-1) % 64;
                if ((masks[u][idx] & (1UL << bit)) != 0) count[lang]++;
            }
        }

        int maxOverlap = 0;
        for (int lang = 1; lang <= n; lang++) maxOverlap = Math.Max(maxOverlap, count[lang]);

        return candidates.Count - maxOverlap;
    }
}