// https://leetcode.com/problems/excel-sheet-column-number
// #math
public class Solution
{
	public int TitleToNumber(string columnTitle)
	{
		int number = 0;
		int power = 1;
		for (int i = columnTitle.Length - 1; i >= 0; --i) {
			number += (columnTitle[i] - 'A' + 1) * power;
			power *= 26;
		}
		return number;
	}
}
