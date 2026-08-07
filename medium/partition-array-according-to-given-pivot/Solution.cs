// https://leetcode.com/problems/partition-array-according-to-given-pivot
// #two_pointers
public class Solution
{
	public int[] PivotArray(int[] nums, int pivot)
	{
		int n = nums.Length;
		var rearrangementArray = new int[nums.Length];
		int lessPartEnd = -1, greaterPartStart = n;
		for (int i = 0; i < n; ++i) {
			if (nums[i] < pivot) {
				rearrangementArray[++lessPartEnd] = nums[i];
			}
			else if (nums[i] > pivot) {
				rearrangementArray[--greaterPartStart] = nums[i];
			}
		}
		for (int i = lessPartEnd + 1; i < greaterPartStart; ++i) {
			rearrangementArray[i] = pivot;
		}
		int greaterNumbersCount = n - greaterPartStart;
		int greaterNumbersPairs = greaterNumbersCount / 2;
		for (int i = 0; i < greaterNumbersPairs; ++i) {
			int a = greaterPartStart + i;
			int b = n - 1 - i;
			(rearrangementArray[a], rearrangementArray[b]) = (rearrangementArray[b], rearrangementArray[a]);
		}
		return rearrangementArray;
	}
}
