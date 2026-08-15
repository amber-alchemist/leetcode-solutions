// https://leetcode.com/problems/rotate-function
// #math #array
public class Solution
{
	public int MaxRotateFunction(int[] nums)
	{
		int n = nums.Length;
		int rotateFunctionValue = 0;
		int rotationDifference = 0;
		for (int i = 0; i < n; ++i) {
			rotateFunctionValue += nums[i] * i;
			rotationDifference += nums[i];
		}
		int maxRotateFunctionValue = rotateFunctionValue;
		for (int i = n - 1; i > 0; --i) {
			rotateFunctionValue += rotationDifference - nums[i] * n;
			maxRotateFunctionValue = Math.Max(maxRotateFunctionValue, rotateFunctionValue);
		}
		return maxRotateFunctionValue;
	}
}
