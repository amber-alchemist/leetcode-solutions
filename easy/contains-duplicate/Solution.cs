// https://leetcode.com/problems/contains-duplicate
// #hash_table
public class Solution
{
	public bool ContainsDuplicate(int[] nums)
	{
		var distinctNumbers = new HashSet<int>();
		for (int i = 0; i < nums.Length; ++i) {
			if (distinctNumbers.Contains(nums[i])) {
				return true;
			}
			distinctNumbers.Add(nums[i]);
		}
		return false;
	}
}
