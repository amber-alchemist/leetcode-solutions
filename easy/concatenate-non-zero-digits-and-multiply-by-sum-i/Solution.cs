// https://leetcode.com/problems/concatenate-non-zero-digits-and-multiply-by-sum-i
// #math
public class Solution
{
	public long SumAndMultiply(int n)
	{
		int x = 0, s = 0, m = 1;
		while (n > 0) {
			n = Math.DivRem(n, 10, out int r);
			if (r != 0) {
				x += m * r;
				m *= 10;
				s += r;
			}
		}
		return (long)x * s;
	}
}
