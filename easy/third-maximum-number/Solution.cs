// https://leetcode.com/problems/third-maximum-number
// #math
public class Solution
{
	public int ThirdMax(int[] nums)
	{
		int? first = null, second = null, third = null;
		for (int i = 0; i < nums.Length; ++i) {
			if (!first.HasValue) {
				first = nums[i];
			}
			else if (first.Value < nums[i]) {
				if (second.HasValue) {
					third = second;
				}
				second = first;
				first = nums[i];
			}
			else if (first.Value > nums[i]) {
				if (!second.HasValue) {
					second = nums[i];
				}
				else if (second.Value < nums[i]) {
					third = second;
					second = nums[i];
				}
				else if (second.Value > nums[i]) {
					if (!third.HasValue || third.Value < nums[i]) {
						third = nums[i];
					}
				}
			}
		}
		return third ?? first.Value;
	}
}
