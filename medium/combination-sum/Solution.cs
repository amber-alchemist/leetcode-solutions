// https://leetcode.com/problems/combination-sum
// #backtracking #combinatorics
public class Solution
{
	public IList<IList<int>> CombinationSum(int[] candidates, int target)
	{
		List<IList<int>> combinations = [];
		GenerateCombination(0, target, []);
		return combinations;

		void GenerateCombination(int index, int left, List<int> combination)
		{
			int candidate = candidates[index];
			int nextIndex = index + 1;
			if (nextIndex < candidates.Length) {
				GenerateCombination(nextIndex, left, combination);
				int count = 0;
				while ((left -= candidate) > 0) {
					combination.Add(candidate);
					++count;
					GenerateCombination(nextIndex, left, combination);
				}
				if (left == 0) {
					var newCombination = combination.Append(candidate).ToList();
					combinations.Add(newCombination);
				}
				for (int i = 0; i < count; ++i) {
					combination.RemoveAt(combination.Count - 1);
				}
			} else {
				int count = Math.DivRem(left, candidate, out int remainder);
				if (remainder == 0) {
					var newCombination = new List<int>(combination);
					for (int i = 0; i < count; ++i) {
						newCombination.Add(candidate);
					}
					combinations.Add(newCombination);
				}
			}
		}
	}
}
