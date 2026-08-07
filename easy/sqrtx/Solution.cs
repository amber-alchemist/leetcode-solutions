// https://leetcode.com/problems/sqrtx
// #math #binary_search
public class Solution
{
	public int MySqrt(int x)
	{
		// Square root of 2^31 - 1 rounded down.
		const int MaxAnswer = 46340;

		if (x <= 1) {
			return x;
		}
		int left = 0, right = Math.Min(x / 2, MaxAnswer);
		while (left < right) {
			int middle = (left + right + 1) / 2;
			int square = middle * middle;
			if (square == x) {
				return middle;
			}
			else if (square < x) {
				left = middle;
			}
			else if (square > x) {
				right = middle - 1;
			}
		}
		return left;
	}
}
