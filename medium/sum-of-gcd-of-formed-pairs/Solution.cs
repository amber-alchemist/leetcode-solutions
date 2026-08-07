// https://leetcode.com/problems/sum-of-gcd-of-formed-pairs
// #number_theory
public class Solution
{
	public long GcdSum(int[] nums)
	{
		int n = nums.Length;
		var prefixGcd = new int[n];
		int currentMaximum = 0;
		for (int i = 0; i < n; ++i) {
            if (currentMaximum <= nums[i]) {
                prefixGcd[i] = currentMaximum = nums[i];
            } else {
                prefixGcd[i] = Gcd(nums[i], currentMaximum);
            }
		}
		Array.Sort(prefixGcd);

		long gcdSum = 0L;
		for (int l = 0, r = n - 1; l < r; ++l, --r) {
            if (prefixGcd[l] == prefixGcd[r]) {
                gcdSum += prefixGcd[l];
            } else {
                gcdSum += Gcd(prefixGcd[l], prefixGcd[r]);
            }
		}
		return gcdSum;
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
