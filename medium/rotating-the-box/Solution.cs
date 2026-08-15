// https://leetcode.com/problems/rotating-the-box
// #array
public class Solution
{
	public char[][] RotateTheBox(char[][] boxGrid)
	{
		int n = boxGrid.Length;
		int m = boxGrid[0].Length;

		var rotatedBox = new char[m][];
		for (int j = 0; j < m; ++j) {
			rotatedBox[j] = new char[n];
		}

		for (int i = 0; i < n; ++i) {
			int lastFree = m - 1;
			for (int j = m - 1; j >= 0; --j) {
				rotatedBox[j][n - 1 - i] = '.';
				if (boxGrid[i][j] == '#') {
					rotatedBox[lastFree--][n - 1 - i] = '#';
				}
				else if (boxGrid[i][j] == '*') {
					rotatedBox[j][n - 1 - i] = '*';
					lastFree = j - 1;
				}
			}
		}
		return rotatedBox;
	}
}
