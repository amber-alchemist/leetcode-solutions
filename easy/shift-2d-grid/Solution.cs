// https://leetcode.com/problems/shift-2d-grid
// #matrix #math
public class Solution
{
	public IList<IList<int>> ShiftGrid(int[][] grid, int k)
	{
		int n = grid.Length, m = grid[0].Length;
		var shiftedGrid = new int[n][];
		for (int i = 0; i < n; ++i) {
			shiftedGrid[i] = new int[m];
		}

		k %= n * m;
		if (k == 0) {
			for (int i = 0; i < n; ++i) {
				for (int j = 0; j < m; ++j) {
					shiftedGrid[i][j] = grid[i][j];
				}
			}
		} else {
			int r = Math.DivRem(k, m, out int c);
			for (int i = 0; i < n; ++i) {
				for (int j = 0; j < m; ++j) {
					shiftedGrid[r][c] = grid[i][j];
					if (++c == m) {
						if (++r == n) {
							r = 0;
						}
						c = 0;
					}
				}
			}
		}
		return shiftedGrid;
	}
}
