// https://leetcode.com/problems/left-and-right-sum-differences
// #prefix_sum
public class Solution
{
	public int[] LeftRightDifference(int[] nums)
	{
		int n = nums.Length;
		int prefixSum = 0;
		for (int i = 0; i < n; ++i) {
			prefixSum += nums[i];
		}

		var differences = new int[n];
		int suffixSum = 0;
		for (int i = n - 1; i >= 0; --i) {
			prefixSum -= nums[i];
			differences[i] = Math.Abs(prefixSum - suffixSum);
			suffixSum += nums[i];
		}
		return differences;
	}
}
