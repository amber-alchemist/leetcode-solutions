// https://leetcode.com/problems/trapping-rain-water
// #two_pointers
public class Solution
{
	public int Trap(int[] height)
	{
		int totalWaterAmount = 0;
		int left = 0, right = height.Length - 1;
		int leftMaxHeight = height[left], rightMaxHeight = height[right];
		while (left < right) {
			if (leftMaxHeight <= rightMaxHeight) {
				++left;
				leftMaxHeight = Math.Max(leftMaxHeight, height[left]);
				totalWaterAmount += leftMaxHeight - height[left];
			}
			else {
				--right;
				rightMaxHeight = Math.Max(rightMaxHeight, height[right]);
				totalWaterAmount += rightMaxHeight - height[right];
			}
		}
		return totalWaterAmount;
	}
}
