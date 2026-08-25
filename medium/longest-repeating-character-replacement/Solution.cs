// https://leetcode.com/problems/longest-repeating-character-replacement
// #sliding_window #string
public class Solution
{
	public int CharacterReplacement(string s, int k)
	{
		var counters = new int[26];
		int maxLetterCode = s[0] - 'A';
		++counters[maxLetterCode];
		int otherNumbersCount = 0;

		int substringStart = 0;
		int longestValidSubstringLength = 1;
		for (int substringEnd = 1; substringEnd < s.Length; ++substringEnd) {
			int currentLetterCode = s[substringEnd] - 'A';
			++counters[currentLetterCode];
			if (currentLetterCode == maxLetterCode) {
				continue;
			}
			++otherNumbersCount;
			if (counters[maxLetterCode] < counters[currentLetterCode]) {
				otherNumbersCount += counters[maxLetterCode] - counters[currentLetterCode];
				maxLetterCode = currentLetterCode;
			} else {
				longestValidSubstringLength = Math.Max(longestValidSubstringLength, substringEnd - substringStart);
				while (otherNumbersCount > k) {
					int startLetterCode = s[substringStart++] - 'A';
					--counters[startLetterCode];
					if (startLetterCode == maxLetterCode) {
						int newMaxLetterCode = maxLetterCode;
						for (int i = 0; i < counters.Length; ++i) {
							if (counters[i] > counters[newMaxLetterCode]) {
								newMaxLetterCode = i;
							}
						}
						if (maxLetterCode != newMaxLetterCode) {
							otherNumbersCount += counters[maxLetterCode] - counters[newMaxLetterCode];
							maxLetterCode = newMaxLetterCode;
						}
					} else {
						--otherNumbersCount;
					}
				}
			}
		}
		longestValidSubstringLength = Math.Max(longestValidSubstringLength, s.Length - substringStart);
		return longestValidSubstringLength;
	}
}
