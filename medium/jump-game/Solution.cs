// https://leetcode.com/problems/jump-game
// #greedy_algorithm
public class Solution
{
	public bool CanJump(int[] nums)
	{
		int requiredJumpLength = 0;
		for (int i = nums.Length - 1; i > 0; --i) {
			if (nums[i] < requiredJumpLength) {
				++requiredJumpLength;
			}
			else {
				requiredJumpLength = 1;
			}
		}
		return nums[0] >= requiredJumpLength;
	}
}
