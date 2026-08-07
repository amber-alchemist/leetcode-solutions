// https://leetcode.com/problems/maximum-total-subarray-value-i
// #greedy_algorithm
public class Solution
{
	public long MaxTotalValue(int[] nums, int k)
	{
		int min = nums[0];
		int max = nums[0];
		for (int i = 1; i < nums.Length; ++i) {
			min = Math.Min(min, nums[i]);
			max = Math.Max(max, nums[i]);
		}
		return (long)(max - min) * k;
	}
}
