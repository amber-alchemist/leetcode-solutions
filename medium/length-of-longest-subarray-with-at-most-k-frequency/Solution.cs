// https://leetcode.com/problems/length-of-longest-subarray-with-at-most-k-frequency
// #two_pointers #hash_table
public class Solution
{
	public int MaxSubarrayLength(int[] nums, int k)
	{
		int longestGoodSubarrayLength = 0;
		var frequencies = new Dictionary<int, int> { [nums[0]] = 1 };
		int left = 0, right = 1;
		while (right < nums.Length) {
			if (!frequencies.TryGetValue(nums[right], out int frequence)) {
				frequence = 0;
			}
			frequencies[nums[right]] = ++frequence;
			if (frequence > k) {
				longestGoodSubarrayLength = Math.Max(longestGoodSubarrayLength, right - left);
				while (left < right) {
					--frequencies[nums[left]];
					if (nums[left++] == nums[right]) {
						break;
					}
				}
			}
			++right;
		}
		longestGoodSubarrayLength = Math.Max(longestGoodSubarrayLength, right - left);
		return longestGoodSubarrayLength;
	}
}
