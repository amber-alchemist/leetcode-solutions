// https://leetcode.com/problems/minimum-distance-to-the-target-element
// #two_pointers
public class Solution
{
	public int GetMinDistance(int[] nums, int target, int start)
	{
		if (nums[start] == target) {
			return 0;
		}

		int distance = 0;
		int left = start, right = start;
		while (left >= 0 || right < nums.Length) {
			++distance;
			if (--left >= 0 && nums[left] == target) {
				return distance;
			}
			if (++right < nums.Length && nums[right] == target) {
				return distance;
			}
		}
		return -1;
	}
}
