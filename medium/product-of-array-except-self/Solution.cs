// https://leetcode.com/problems/product-of-array-except-self
// #prefix_sum
public class Solution
{
	public int[] ProductExceptSelf(int[] nums)
	{
		int n = nums.Length;
		var suffixProducts = new int[n];
		suffixProducts[n - 1] = 1;
		for (int i = n - 2; i >= 0; --i) {
			suffixProducts[i] = suffixProducts[i + 1] * nums[i + 1];
		}

		var result = new int[n];
		result[0] = suffixProducts[0];

		int prefixProduct = 1;
		for (int i = 1; i < n; ++i) {
			prefixProduct *= nums[i - 1];
			result[i] = prefixProduct * suffixProducts[i];
		}
		return result;
	}
}
