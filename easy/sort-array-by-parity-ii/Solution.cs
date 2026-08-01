// https://leetcode.com/problems/sort-array-by-parity-ii
// #two_pointers
public class Solution
{
	public int[] SortArrayByParityII(int[] nums)
	{
		int evenIndex = 0, oddIndex = 1;
		while (evenIndex <= nums.Length - 2) {
			if (nums[evenIndex] % 2 == 1) {
				while (nums[oddIndex] % 2 == 1) {
					oddIndex += 2;
				}
				(nums[evenIndex], nums[oddIndex]) = (nums[oddIndex], nums[evenIndex]);
			}
			evenIndex += 2;
		}
		return nums;
	}
}
