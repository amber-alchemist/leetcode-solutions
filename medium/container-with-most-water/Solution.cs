// https://leetcode.com/problems/container-with-most-water
// #two_pointers
public class Solution
{
	public int MaxArea(int[] height)
	{
		int maxArea = 0;
		int left = 0, right = height.Length - 1;
		while (left < right) {
			int length = right - left;
			int currentHeight = height[left] < height[right] ? height[left++] : height[right--];
			maxArea = Math.Max(maxArea, length * currentHeight);
		}
		return maxArea;
	}
}
