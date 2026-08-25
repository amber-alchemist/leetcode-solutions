// https://leetcode.com/problems/rank-transform-of-an-array
// #hash_table
public class Solution
{
	public int[] ArrayRankTransform(int[] arr)
	{
		int n = arr.Length;
		var indicesByValue = new SortedDictionary<int, List<int>>();
		for (int i = 0; i < n; ++i) {
			if (!indicesByValue.TryGetValue(arr[i], out var indicesList)) {
				indicesByValue[arr[i]] = indicesList = new List<int>();
			}
			indicesList.Add(i);
		}

		int currentRank = 1;
		foreach (var indices in indicesByValue.Values) {
			for (int i = 0; i < indices.Count; ++i) {
				arr[indices[i]] = currentRank;
			}
			++currentRank;
		}
		return arr;
	}
}

