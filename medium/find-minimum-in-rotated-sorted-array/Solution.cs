// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array
// #two_pointers
public class Solution
{
	public int FindMin(int[] nums)
	{
		int left = 0, right = nums.Length - 1;
		if (nums[left] <= nums[right]) {
			return nums[left];
		}
		while (left + 1 < right) {
			int middle = (left + right) / 2;
			if (nums[left] < nums[middle]) {
				left = middle;
			}
			else {
				right = middle;
			}
		}
		return nums[right];
	}
}
