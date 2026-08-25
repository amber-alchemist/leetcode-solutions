// https://leetcode.com/problems/smallest-missing-multiple-of-k
// #hash_table
public class Solution
{
	public int MissingMultiple(int[] nums, int k)
	{
		const int MaxValue = 100;

		var set = new HashSet<int>();
		for (int i = 0; i < nums.Length; ++i) {
			if (nums[i] % k == 0) {
				set.Add(nums[i]);
			}
		}

		int smallestMissingMultiple = k;
		while (smallestMissingMultiple <= MaxValue && set.Contains(smallestMissingMultiple)) {
			smallestMissingMultiple += k;
		}
		return smallestMissingMultiple;
	}
}
