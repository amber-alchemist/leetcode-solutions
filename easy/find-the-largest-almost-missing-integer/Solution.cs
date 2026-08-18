// https://leetcode.com/problems/find-the-largest-almost-missing-integer
// #array #combinatorics
public class Solution
{
	public int LargestInteger(int[] nums, int k)
	{
		const int MaxValue = 50;

		int n = nums.Length;
		int largestAlmostMissingNumber = -1;
		if (k == n) {
			for (int i = 0; i < n; ++i) {
				largestAlmostMissingNumber = Math.Max(largestAlmostMissingNumber, nums[i]);
			}
		}
		else {
			var counters = new int[MaxValue + 1];
			for (int i = 0; i < n; ++i) {
				++counters[nums[i]];
			}
			if (k == 1) {
				for (int i = MaxValue; i >= 0; --i) {
					if (counters[i] == 1) {
						largestAlmostMissingNumber = i;
						break;
					}
				}
			}
			else {
				largestAlmostMissingNumber = Math.Max(
					counters[nums[0]] == 1 ? nums[0] : -1,
					counters[nums[n - 1]] == 1 ? nums[n - 1] : -1
				);
			}
		}
		return largestAlmostMissingNumber;
	}
}
