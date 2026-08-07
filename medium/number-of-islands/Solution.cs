// https://leetcode.com/problems/number-of-islands
// #graph_theory #dfs
public class Solution
{
	public int NumIslands(char[][] grid)
	{
		int n = grid.Length, m = grid[0].Length;
		int islandsNumber = 0;
		for (int i = 0; i < n; ++i) {
			for (int j = 0; j < m; ++j) {
				if (grid[i][j] == '1') {
					grid[i][j] = '2';
					Dfs(i, j);
					++islandsNumber;
					continue;
				}
			}
		}
		return islandsNumber;

		void Dfs(int x, int y)
		{
			if (x > 0 && grid[x - 1][y] == '1') {
				grid[x - 1][y] = '2';
				Dfs(x - 1, y);
			}
			if (y + 1 < m && grid[x][y + 1] == '1') {
				grid[x][y + 1] = '2';
				Dfs(x, y + 1);
			}
			if (x + 1 < n && grid[x + 1][y] == '1') {
				grid[x + 1][y] = '2';
				Dfs(x + 1, y);
			}
			if (y > 0 && grid[x][y - 1] == '1') {
				grid[x][y - 1] = '2';
				Dfs(x, y - 1);
			}
		}
	}
}
