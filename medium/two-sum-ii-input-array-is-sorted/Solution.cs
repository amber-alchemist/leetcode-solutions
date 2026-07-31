// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted
// #two_pointers
public class Solution
{
	public int[] TwoSum(int[] numbers, int target)
	{
		int n = numbers.Length;
		int left = 0, right = n - 1;
		while (left != right) {
			int sum = numbers[left] + numbers[right];
			if (sum == target) {
				return [left + 1, right + 1];
			} else if (sum < target) {
				++left;
			} else {
				--right;
			}
		}
		throw new InvalidOperationException();
	}
}
