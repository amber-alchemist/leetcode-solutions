// https://leetcode.com/problems/smallest-divisible-digit-product-i
// #number_theory
public class Solution
{
	public int SmallestNumber(int n, int t)
	{
		int x = Math.DivRem(n, 10, out int y);
		int p = x == 0 ? y : x * y;
		while (p % t != 0) {
			if (++y == 10) {
				y = 0;
				++x;
			}
			p = y == 0 ? 0 : p + (x == 0 ? 1 : x);
		}
		return 10 * x + y;
	}
}
