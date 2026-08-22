// https://leetcode.com/problems/minimum-distance-between-three-equal-elements-ii
// #array #hash_table
public class Solution
{
	public int MinimumDistance(int[] nums)
	{
		int bestDistance = int.MaxValue;
		var indicesPerDistinctNumbers = new Dictionary<int, int[]>();
		for (int i = 0; i < nums.Length; ++i) {
			if (!indicesPerDistinctNumbers.TryGetValue(nums[i], out var indices)) {
				indicesPerDistinctNumbers[nums[i]] = [i, -1, -1];
			}
			else {
				if (indices[1] == -1) {
					indices[1] = i;
					continue;
				}
				if (indices[2] == -1) {
					indices[2] = i;
				}
				else {
					indices[0] = indices[1];
					indices[1] = indices[2];
					indices[2] = i;
				}
				int distance = (indices[2] - indices[0]) << 1;
				bestDistance = Math.Min(bestDistance, distance);
			}
		}
		return bestDistance < int.MaxValue ? bestDistance : -1;
	}
}
