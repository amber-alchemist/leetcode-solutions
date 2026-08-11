// https://leetcode.com/problems/remove-duplicates-from-sorted-array
// #array
public class Solution
{
	public int RemoveDuplicates(int[] nums)
	{
		int distinctNumbersCount = 1;
		int currentDistinctIndex = 0;
		int sortedIndex = 0;
		for (int i = 1; i < nums.Length; ++i) {
			if (nums[i] != nums[currentDistinctIndex]) {
				++distinctNumbersCount;
				currentDistinctIndex = i;
				nums[++sortedIndex] = nums[i];
			}
		}
		return distinctNumbersCount;
	}
}
