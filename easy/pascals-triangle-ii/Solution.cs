// https://leetcode.com/problems/pascals-triangle-ii
// #array #math
public class Solution
{
	public IList<int> GetRow(int rowIndex)
	{
		int n = rowIndex + 1;
		long value = 1L;

		var row = new int[n];
		row[0] = row[n - 1] = (int)value;
		
		int m = (n >> 1) + (n & 1);
		for (int k = 1; k < m; ++k) {
			value = value * (n - k - 1) / (k + 1);
			row[k] = row[n - 1 - k] = (int)value;
		}
		return row;
	}
}
