// https://leetcode.com/problems/contains-duplicate-ii
// #hash_table
public class Solution
{
	public bool ContainsNearbyDuplicate(int[] nums, int k)
	{
		var occurrences = new Dictionary<int, int>();
		for (int i = 0; i < nums.Length; ++i) {
			if (occurrences.TryGetValue(nums[i], out int lastIndex)) {
				if (i - lastIndex <= k) {
					return true;
				}
			}
			occurrences[nums[i]] = i;
		}
		return false;
	}
}
