// https://leetcode.com/problems/weighted-word-mapping
// #string #math
public class Solution
{
	public string MapWordWeights(string[] words, int[] weights)
	{
		int n = words.Length;
		var wordsWeights = new char[n];
		for (int i = 0; i < n; ++i) {
			int weight = 0;
			for (int j = 0; j < words[i].Length; ++j) {
				weight += weights[words[i][j] - 'a'];
			}
			wordsWeights[i] = (char)('z' - weight % 26);
		}
		return new string(wordsWeights);
	}
}
