// https://leetcode.com/problems/minimum-element-after-replacement-with-digit-sum
// #math
public class Solution
{
	public int MinElement(int[] nums)
	{
		int minDigitsSum = int.MaxValue;
		for (int i = 0; i < nums.Length; ++i) {
			int number = nums[i];
			int digitsSum = 0;
			while (number > 0) {
				number = Math.DivRem(number, 10, out int remainder);
				digitsSum += remainder;
			}
			minDigitsSum = Math.Min(minDigitsSum, digitsSum);
		}
		return minDigitsSum;
	}
}
