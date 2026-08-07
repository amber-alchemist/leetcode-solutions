// https://leetcode.com/problems/search-insert-position
// #binary_search
public class Solution
{
	public int SearchInsert(int[] nums, int target)
	{
		int left = 0, right = nums.Length - 1;
		while (left <= right) {
			int middle = (left + right) / 2;
			if (nums[middle] == target) {
				return middle;
			}
			else if (nums[middle] > target) {
				right = middle - 1;
			}
			else {
				left = middle + 1;
			}
		}
		return left;
	}
}
