// https://leetcode.com/problems/majority-element
// #majority_vote_algorithm
public class Solution
{
	public int MajorityElement(int[] nums)
	{
		int candidate = nums[0];
		int votes = 1;
		for (int i = 1; i < nums.Length; ++i) {
			if (votes == 0) {
				candidate = nums[i];
			}
			else {
				votes += nums[i] == candidate ? 1 : -1;
			}
		}
		return candidate;
	}
}
