// https://leetcode.com/problems/permutations
// #backtracking #combinatorics
public class Solution
{
	public IList<IList<int>> Permute(int[] nums)
	{
		int permutationsCount = 1;
		for (int i = 2; i <= nums.Length; ++i) {
			permutationsCount *= i;
		}
		int permutationsIndex = 0;
		var permutations = new IList<int>[permutationsCount];
		var isNumberUsed = new bool[nums.Length];
		var currentPermutation = new int[nums.Length];
		PermuteHelper(0);
		return permutations;

		void PermuteHelper(int index)
		{
			if (index == nums.Length) {
				var newPermutation = new int[nums.Length];
				Array.Copy(currentPermutation, newPermutation, nums.Length);
				permutations[permutationsIndex++] = newPermutation;
			}
			else {
				for (int i = 0; i < nums.Length; ++i) {
					if (isNumberUsed[i]) {
						continue;
					}
					isNumberUsed[i] = true;
					currentPermutation[index] = nums[i];
					PermuteHelper(index + 1);
					isNumberUsed[i] = false;
				}
			}
		}
	}
}
