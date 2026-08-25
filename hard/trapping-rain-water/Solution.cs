// https://leetcode.com/problems/trapping-rain-water
// #two_pointers
public class Solution
{
	public int Trap(int[] height)
	{
		int totalWaterAmount = 0;

		int rightBorder = height.Length - 1;
		int left = 0;
		while (left < rightBorder && height[left] <= height[left + 1]) {
			++left;
		}

		int preWaterAmount = 0;
		int right = left + 1;
		for (; right <= rightBorder; ++right) {
			if (height[right] >= height[left]) {
				totalWaterAmount += preWaterAmount;
				preWaterAmount = 0;
				left = right;
			}
			else {
				preWaterAmount += height[left] - height[right];
			}
		}

		int leftBorder = left;
		right = rightBorder;
		while (right > leftBorder && height[right - 1] >= height[right]) {
			--right;
		}

		preWaterAmount = 0;
		left = right - 1;
		for (; left >= leftBorder; --left) {
			if (height[left] >= height[right]) {
				totalWaterAmount += preWaterAmount;
				preWaterAmount = 0;
				right = left;
			}
			else {
				preWaterAmount += height[right] - height[left];
			}
		}
		return totalWaterAmount;
	}
}
