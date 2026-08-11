// https://leetcode.com/problems/pascals-triangle
// #array #math
public class Solution
{
	public IList<IList<int>> Generate(int numRows)
	{
		var triangle = new IList<int>[numRows];
		int[] prevRow = null;
		for (int i = 1; i <= numRows; ++i) {
			var row = new int[i];
			row[0] = 1;
			for (int j = 1; j < i - 1; ++j) {
				row[j] = prevRow[j - 1] + prevRow[j];
			}
			row[i - 1] = 1;
			triangle[i - 1] = row;
			prevRow = row;
		}
		return triangle;
	}
}
