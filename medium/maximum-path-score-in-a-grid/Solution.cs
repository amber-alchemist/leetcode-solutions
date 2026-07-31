// https://leetcode.com/problems/maximum-path-score-in-a-grid
// #dynamic_programming
public class Solution
{
	public int MaxPathScore(int[][] grid, int k)
	{
		const int NotVisitedValue = -1;

		int n = grid.Length, m = grid[0].Length;

		int[,,] dp = new int[2, m, k + 1];
		for (int j = 0; j < m; ++j) {
			for (int p = 0; p <= k; ++p) {
				dp[0, j, p] = NotVisitedValue;
				dp[1, j, p] = NotVisitedValue;
			}
		}

		dp[0, 0, 0] = 0;
		for (int j = 1; j < m; ++j) {
			int value = grid[0][j];
			int cost = value > 0 ? 1 : 0;
			int limit = k - cost;
			for (int p = 0; p <= limit; ++p) {
				if (dp[0, j - 1, p] != NotVisitedValue) {
					dp[0, j, p + cost] = dp[0, j - 1, p] + value;
				}
			}
		}

		int read = 0, write = 1;
		for (int i = 1; i < n; ++i) {
			for (int j = 0; j < m; ++j) {
				int value = grid[i][j];
				int cost = value > 0 ? 1 : 0;
				int limit = k - cost;
				for (int p = 0; p <= limit; ++p) {
					int topValue = dp[read, j, p];
					int leftValue = j > 0 ? dp[write, j - 1, p] : NotVisitedValue;
					if (topValue != NotVisitedValue || leftValue != NotVisitedValue) {
						dp[write, j, p + cost] = Math.Max(topValue, leftValue) + value;
					}
				}
				for (int p = 0; p <= k; ++p) {
					dp[read, j, p] = NotVisitedValue;
				}
			}
			(read, write) = (write, read);
		}

		int maxScore = dp[read, m - 1, 0];
		for (int p = 1; p <= k; ++p) {
			maxScore = Math.Max(maxScore, dp[read, m - 1, p]);
		}
		return maxScore;
	}
}
