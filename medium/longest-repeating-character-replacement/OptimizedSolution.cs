// https://leetcode.com/problems/longest-repeating-character-replacement
// #sliding_window #string
public class Solution
{
	public int CharacterReplacement(string s, int k)
	{
		int longestValidSubstringLength = 0;

		var counters = new int[26];
		int maxFrequence = 0;
		int substringStart = 0;
		for (int substringEnd = 0; substringEnd < s.Length; ++substringEnd) {
			int currentLetterCode = s[substringEnd] - 'A';
			maxFrequence = Math.Max(maxFrequence, ++counters[currentLetterCode]);
			int substringLength = substringEnd - substringStart + 1;
			int otherLettersCount = substringLength - maxFrequence;
			if (otherLettersCount > k) {
				int startLetterCode = s[substringStart++] - 'A';
				--counters[startLetterCode];
				--substringLength;
			}
			longestValidSubstringLength = Math.Max(longestValidSubstringLength, substringLength);
		}
		longestValidSubstringLength = Math.Max(longestValidSubstringLength, s.Length - substringStart);
		return longestValidSubstringLength;
	}
}
