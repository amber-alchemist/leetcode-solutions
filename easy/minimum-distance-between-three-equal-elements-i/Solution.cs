// https://leetcode.com/problems/minimum-distance-between-three-equal-elements-i
// #hash_table #math
public class Solution
{
	public int MinimumDistance(int[] nums)
	{
		var indicesPerDistinctNumbers = new Dictionary<int, List<int>>();
		for (int i = 0; i < nums.Length; ++i) {
			if (!indicesPerDistinctNumbers.TryGetValue(nums[i], out List<int> indices)) {
				indicesPerDistinctNumbers[nums[i]] = indices = [];
			}
			indices.Add(i);
		}

		int bestDistance = int.MaxValue;
		foreach (var indices in indicesPerDistinctNumbers.Values) {
			if (indices.Count < 3) {
				continue;
			}
			for (int i = 0; i < indices.Count - 2; ++i) {
				int distance = 2 * (indices[i + 2] - indices[i]);
				bestDistance = Math.Min(bestDistance, distance);
			}
		}
		return bestDistance < int.MaxValue ? bestDistance : -1;
	}
}
