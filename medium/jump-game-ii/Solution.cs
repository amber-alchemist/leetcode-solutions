// https://leetcode.com/problems/jump-game-ii
// #greedy_algorithm
public class Solution
{
	public int Jump(int[] nums)
	{
		int targetPosition = nums.Length - 1;
		if (targetPosition == 0) {
			return 0;
		}

		int selectionStart = 1;
		int selectionEnd = nums[0];
		if (selectionEnd >= targetPosition) {
			return 1;
		}

		int minimalJumpsNumber = 0;
		while (true) {
			int furthestAfterJumpPosition = 0;
			for (int p = selectionStart; p <= selectionEnd; ++p) {
				int afterJumpPosition = p + nums[p];
				if (afterJumpPosition >= targetPosition) {
					return minimalJumpsNumber + 2;
				}
				if (afterJumpPosition > furthestAfterJumpPosition) {
					furthestAfterJumpPosition = afterJumpPosition;
				}
			}
			selectionStart = selectionEnd + 1;
			selectionEnd = furthestAfterJumpPosition;
			++minimalJumpsNumber;
		}
	}
}
