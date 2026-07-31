// https://leetcode.com/problems/subsets
// #backtracking #combinatorics
public class Solution
{
	public IList<IList<int>> Subsets(int[] nums)
	{
		int subsetsCount = 1 << nums.Length;
		var subsets = new int[subsetsCount][];
		int subsetIndex = 0;
		GenerateSubsets(0, subsets[subsetIndex++] = []);
		return subsets;

		void GenerateSubsets(int numberIndex, int[] previousSubset)
		{
			var subsetWith = new int[previousSubset.Length + 1];
			Array.Copy(previousSubset, subsetWith, previousSubset.Length);
			subsetWith[^1] = nums[numberIndex];
			subsets[subsetIndex++] = subsetWith;
			int nextIndex = numberIndex + 1;
			if (nextIndex < nums.Length) {
				GenerateSubsets(nextIndex, subsetWith);
				GenerateSubsets(nextIndex, previousSubset);
			}
		}
	}
}
