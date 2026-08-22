// https://leetcode.com/problems/count-subarrays-with-majority-element-i
// #array
public class Solution
{
	public int CountMajoritySubarrays(int[] nums, int target)
	{
		int majoritySubarraysCount = 0;
		for (int i = 0; i < nums.Length; ++i) {
			int targetCount = 0;
			int otherCount = 0;
			for (int j = i; j < nums.Length; ++j) {
				if (nums[j] == target) {
					++targetCount;
				}
				else {
					++otherCount;
				}
				if (targetCount > otherCount) {
					++majoritySubarraysCount;
				}
			}
		}
		return majoritySubarraysCount;
	}
}
