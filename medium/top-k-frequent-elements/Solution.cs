// https://leetcode.com/problems/top-k-frequent-elements
// #hash_table #sorting
public class Solution
{
	public int[] TopKFrequent(int[] nums, int k)
	{
		var frequencePerNumber = new Dictionary<int, int>();
		foreach (int number in nums) {
			if (!frequencePerNumber.TryGetValue(number, out int frequence)) {
				frequence = 0;
			}
			frequencePerNumber[number] = frequence + 1;
		}

		var numberPerFrequence = new List<(int frequence, int number)>(frequencePerNumber.Count);
		foreach ((int number, int frequence) in frequencePerNumber) {
			numberPerFrequence.Add((frequence, number));
		}
		numberPerFrequence.Sort();

		var topFrequent = new int[k];
		for (int i = 0; i < k; ++i) {
			int j = numberPerFrequence.Count - 1 - i;
			topFrequent[i] = numberPerFrequence[j].number;
		}
		return topFrequent;
	}
}
