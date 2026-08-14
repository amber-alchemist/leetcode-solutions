// https://leetcode.com/problems/maximum-length-substring-with-two-occurrences
// #string #sliding_window
public class Solution
{
	public int MaximumLengthSubstring(string s)
	{
		const int AlphabetSize = 26;

		int maxSubstringLength = 0;
		var occurerences = new int[AlphabetSize];
		int start = 0, end = 0;
		while (end < s.Length) {
			if (++occurerences[s[end] - 'a'] > 2) {
				maxSubstringLength = Math.Max(maxSubstringLength, end - start);
				while (start < end) {
					--occurerences[s[start] - 'a'];
					if (s[start++] == s[end]) {
						break;
					}
				}
			}
			++end;
		}
		maxSubstringLength = Math.Max(maxSubstringLength, end - start);
		return maxSubstringLength;
	}
}

