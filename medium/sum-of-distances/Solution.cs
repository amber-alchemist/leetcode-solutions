// https://leetcode.com/problems/sum-of-distances
// #prefix_sum #hash_table
public class Solution
{
	public long[] Distance(int[] nums)
	{
		var distancesSums = new long[nums.Length];
		var numbersOccurences = new Dictionary<int, List<int>>();
		for (int i = 0; i < nums.Length; ++i) {
			if (!numbersOccurences.TryGetValue(nums[i], out var indicesList)) {
				indicesList = numbersOccurences[nums[i]] = [];
			}
			indicesList.Add(i);
			distancesSums[indicesList[0]] += i - indicesList[0];
		}

		foreach (var indicesList in numbersOccurences.Values) {
			long leftSum = 0L;
			long rightSum = distancesSums[indicesList[0]];

			int elementsOnLeft = 1;
			int elementsOnRight = indicesList.Count - 1;
			for (int i = 1; i < indicesList.Count; ++i) {
				int diff = indicesList[i] - indicesList[i - 1];
				leftSum += diff * elementsOnLeft++;
				rightSum -= diff * elementsOnRight--;
				distancesSums[indicesList[i]] = leftSum + rightSum;
			}
		}
		return distancesSums;
	}
}
