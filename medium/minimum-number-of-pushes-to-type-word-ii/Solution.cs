// https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-ii
// #greedy_algorithm #sorting
public class Solution
{
	public int MinimumPushes(string word)
	{
		const int AlphabetSize = 26;

		var lettersFrequencies = new int[AlphabetSize];
		for (int i = 0; i < word.Length; ++i) {
			++lettersFrequencies[word[i] - 'a'];
		}
		Array.Sort(lettersFrequencies);

		int minimumPushes = 0;
		int pushesPerLetter = 1;
		int letterNumber = 0;
		for (int i = AlphabetSize - 1; i >= 0 && lettersFrequencies[i] > 0; --i) {
			if (letterNumber++ == 8) {
				++pushesPerLetter;
				letterNumber = 1;
			}
			minimumPushes += lettersFrequencies[i] * pushesPerLetter;
		}
		return minimumPushes;
	}
}
