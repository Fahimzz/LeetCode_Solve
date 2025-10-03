public class Solution {
    public int TrapRainWater(int[][] heightMap) {
        int m = heightMap.Length;
        int n = heightMap[0].Length;
        if (m <= 2 || n <= 2) return 0; // No room to trap water

        bool[,] seen = new bool[m, n];
        var pq = new PriorityQueue<(int r, int c, int h), int>();

        //  Add boundary cells to the priority queue
        for (int i = 0; i < m; i++) {
            pq.Enqueue((i, 0, heightMap[i][0]), heightMap[i][0]);
            pq.Enqueue((i, n - 1, heightMap[i][n - 1]), heightMap[i][n - 1]);
            seen[i, 0] = seen[i, n - 1] = true;
        }

        for (int j = 1; j < n - 1; j++) {
            pq.Enqueue((0, j, heightMap[0][j]), heightMap[0][j]);
            pq.Enqueue((m - 1, j, heightMap[m - 1][j]), heightMap[m - 1][j]);
            seen[0, j] = seen[m - 1, j] = true;
        }

        //  Directions for BFS
        int[][] dirs = new int[][] {
            new int[] {1, 0}, new int[] {-1, 0},
            new int[] {0, 1}, new int[] {0, -1}
        };

        int res = 0;

        //  BFS with priority queue
        while (pq.Count > 0) {
            var cell = pq.Dequeue();
            int r = cell.r;
            int c = cell.c;
            int h = cell.h;

            foreach (var d in dirs) {
                int nr = r + d[0];
                int nc = c + d[1];

                if (nr >= 0 && nr < m && nc >= 0 && nc < n && !seen[nr, nc]) {
                    seen[nr, nc] = true;

                    //  If neighbor is lower → trap water
                    if (heightMap[nr][nc] < h) {
                        res += h - heightMap[nr][nc];
                    }

                    // Push neighbor with updated boundary height
                    pq.Enqueue((nr, nc, Math.Max(heightMap[nr][nc], h)), Math.Max(heightMap[nr][nc], h));
                }
            }
        }

        return res;
    }
}