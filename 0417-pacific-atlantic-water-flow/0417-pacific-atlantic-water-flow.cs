public class Solution {
    private static readonly int[][] dirs = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, new int[] {0, 1}, new int[] {0, -1}
    };

    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        int m = heights.Length;
        int n = heights[0].Length;

        bool[,] pacific = new bool[m, n];
        bool[,] atlantic = new bool[m, n];
        Queue<(int, int)> pacificQueue = new Queue<(int, int)>();
        Queue<(int, int)> atlanticQueue = new Queue<(int, int)>();

        // Pacific: top row and left column
        for (int i = 0; i < m; i++) {
            pacific[i, 0] = true;
            pacificQueue.Enqueue((i, 0));
        }
        for (int j = 0; j < n; j++) {
            pacific[0, j] = true;
            pacificQueue.Enqueue((0, j));
        }

        // Atlantic: bottom row and right column
        for (int i = 0; i < m; i++) {
            atlantic[i, n - 1] = true;
            atlanticQueue.Enqueue((i, n - 1));
        }
        for (int j = 0; j < n; j++) {
            atlantic[m - 1, j] = true;
            atlanticQueue.Enqueue((m - 1, j));
        }

        BFS(heights, pacificQueue, pacific);
        BFS(heights, atlanticQueue, atlantic);

        List<IList<int>> ans = new List<IList<int>>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (pacific[i, j] && atlantic[i, j]) ans.Add(new List<int> { i, j });
            }
        }
        return ans;
    }

    private void BFS(int[][] matrix, Queue<(int, int)> q, bool[,] visited) {
        int m = matrix.Length;
        int n = matrix[0].Length;

        while (q.Count > 0) {
            var (i, j) = q.Dequeue();

            foreach (var dir in dirs) {
                int x = i + dir[0];
                int y = j + dir[1];

                if (x < 0 || y < 0 || x >= m || y >= n)
                    continue;

                if (!visited[x, y] && matrix[x][y] >= matrix[i][j]) {
                    visited[x, y] = true;
                    q.Enqueue((x, y));
                }
            }
        }
    }
}