// https://leetcode.com/problems/minimum-absolute-distance-between-mirror-pairs
// #array #math #hash_table
public class Solution
{
	public int MinMirrorPairDistance(int[] nums)
	{
		int minDistance = nums.Length;
		var reversedNums = new Dictionary<int, int>();
		for (int i = 1; i < nums.Length; ++i) {
			int previousReversed = ReverseNumber(nums[i - 1]);
			if (nums[i] == previousReversed) {
				return 1;
			}
			if (reversedNums.TryGetValue(nums[i], out int index)) {
				minDistance = Math.Min(minDistance, i - index);
			}
			reversedNums[previousReversed] = i - 1;
		}
		return minDistance == nums.Length ? -1 : minDistance;

		int ReverseNumber(int sourceNumber)
		{
			int reversed = 0;
			while (sourceNumber > 0) {
				int digit = sourceNumber % 10;
				sourceNumber /= 10;
				reversed = reversed * 10 + digit;
			}
			return reversed;
		}
	}
}
