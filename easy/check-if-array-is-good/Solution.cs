// https://leetcode.com/problems/check-if-array-is-good
// #array
public class Solution
{
	public bool IsGood(int[] nums)
	{
		int n = nums.Length;
		int m = n - 1;
		var frequencies = new int[n];
		for (int i = 0; i < n; ++i) {
			if (nums[i] >= n) {
				return false;
			}
			int count = ++frequencies[nums[i]];
			if (nums[i] == m && count > 2 || nums[i] < m && count > 1) {
				return false;
			}
		}

		for (int i = 1; i < m; ++i) {
			if (frequencies[i] != 1) {
				return false;
			}
		}
		return frequencies[m] == 2;
	}
}
