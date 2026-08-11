// https://leetcode.com/problems/smallest-missing-integer-greater-than-sequential-prefix-sum
// #array
public class Solution
{
	public int MissingInteger(int[] nums)
	{
		const int MaxNumber = 50;

		var frequencies = new int[MaxNumber + 1];
		++frequencies[nums[0]];

		bool isSequentialPrefixContinue = true;
		int sequentialPrefixSum = nums[0];
		for (int i = 1; i < nums.Length; ++i) {
			if (isSequentialPrefixContinue) {
				if (nums[i - 1] + 1 != nums[i]) {
					isSequentialPrefixContinue = false;
				}
				else {
					sequentialPrefixSum += nums[i];
				}
			}
			++frequencies[nums[i]];
		}
		
		if (sequentialPrefixSum > MaxNumber) {
			return sequentialPrefixSum;
		}
		for (int i = sequentialPrefixSum; i <= MaxNumber; ++i) {
			if (frequencies[i] == 0) {
				return i;
			}
		}
		return MaxNumber + 1;
	}
}
