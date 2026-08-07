// https://leetcode.com/problems/jump-game-ix
// #dynamic_programming
public class Solution
{
	public int[] MaxValue(int[] nums)
	{
		int n = nums.Length;

		var result = new int[n];
		var takenFrom = new int[n];
		(int value, int index) currentMaximum = (-1, -1);
		for (int i = 0; i < n; ++i) {
			if (nums[i] > currentMaximum.value) {
				currentMaximum = (nums[i], i);
				takenFrom[i] = i;
				result[i] = nums[i];
			}
			else if (nums[i] == currentMaximum.value) {
				takenFrom[i] = i;
				result[i] = nums[i];
			}
			else {
				takenFrom[i] = currentMaximum.index;
				result[i] = currentMaximum.value;
			}
		}

		(int value, int index) currentMinimum = (nums[n - 1], n - 1);
		for (int i = n - 2; i >= 0; --i) {
			if (nums[takenFrom[i]] > currentMinimum.value) {
				result[i] = Math.Max(result[i], result[currentMinimum.index]);
			}
			if (nums[i] < currentMinimum.value) {
				currentMinimum = (nums[i], i);
			}
		}

		return result;
	}
}
