// https://leetcode.com/problems/find-greatest-common-divisor-of-array
// #number_theory
public class Solution
{
	public int FindGCD(int[] nums)
	{
		int min = nums[0], max = nums[0];
		for (int i = 1; i < nums.Length; ++i) {
			min = Math.Min(min, nums[i]);
			max = Math.Max(max, nums[i]);
		}
		return Gcd(min, max);
	}

	private int Gcd(int a, int b)
	{
		if (b > a) {
			(a, b) = (b, a);
		}
		if (b == 1) {
			return 1;
		}
		while (b > 0) {
			a %= b;
			(a, b) = (b, a);
		}
		return a;
	}
}
