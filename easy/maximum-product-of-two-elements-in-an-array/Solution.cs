// https://leetcode.com/problems/maximum-product-of-two-elements-in-an-array
// #array #math
public class Solution
{
	public int MaxProduct(int[] nums)
	{
		int first = nums[0];
		int second = int.MinValue;
		for (int i = 1; i < nums.Length; ++i) {
			if (nums[i] > second) {
				second = nums[i];
				if (second > first) {
					(first, second) = (second, first);
				}
			}
		}
		return (first - 1) * (second - 1);
	}
}
