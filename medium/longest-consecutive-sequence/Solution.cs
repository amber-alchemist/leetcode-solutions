// https://leetcode.com/problems/longest-consecutive-sequence
// #hash_table
public class Solution
{
	public int LongestConsecutive(int[] nums)
	{
		int longestConsecutiveLength = 0;
		var numbersSet = new HashSet<int>(nums);
		var sequencesLengthsPerFirstNumber = new Dictionary<int, int>();
		for (int i = 0; i < nums.Length; ++i) {
			int nextNumber = nums[i];
			while (numbersSet.Contains(nextNumber)) {
				numbersSet.Remove(nextNumber);
				++nextNumber;
			}
			int currentSequenceLength = nextNumber - nums[i];
			if (sequencesLengthsPerFirstNumber.TryGetValue(nextNumber, out int nextSequenceLength)) {
				currentSequenceLength += nextSequenceLength;
			}
			sequencesLengthsPerFirstNumber[nums[i]] = currentSequenceLength;
			longestConsecutiveLength = Math.Max(longestConsecutiveLength, currentSequenceLength);
		}
		return longestConsecutiveLength;
	}
}
