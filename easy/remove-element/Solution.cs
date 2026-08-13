// https://leetcode.com/problems/remove-element
// #array
public class Solution
{
	public int RemoveElement(int[] nums, int val)
	{
		int currentIndex = 0, goodBorder = nums.Length - 1;
		while (currentIndex <= goodBorder) {
			if (nums[currentIndex] == val) {
				(nums[currentIndex], nums[goodBorder]) = (nums[goodBorder], nums[currentIndex]);
				--goodBorder;
			}
			else {
				++currentIndex;
			}
		}
		return goodBorder + 1;
	}
}
