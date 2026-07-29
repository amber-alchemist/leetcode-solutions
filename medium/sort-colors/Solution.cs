// https://leetcode.com/problems/sort-colors
// #two_pointers
public class Solution
{
	public void SortColors(int[] nums)
	{
		// Invariant: all elements before left are 0, and all elements after right are 2.
		int left = 0, right = nums.Length - 1;
		for (int middle = left; middle <= right; ++middle) {
			for (; middle < right && nums[middle] == 2; --right) {
				(nums[middle], nums[right]) = (nums[right], nums[middle]);
			}
			if (nums[middle] == 0) {
				(nums[middle], nums[left]) = (nums[left++], 0);
			}
		}
	}
}
