// https://leetcode.com/problems/lexicographically-smallest-permutation-greater-than-target
// #string #combinatorics
public class Solution
{
	public string LexGreaterPermutation(string s, string target)
	{
		const int AlphabetSize = 26;

		int n = s.Length;
		if (n == 1) {
			return s[0] > target[0] ? s[0..1] : string.Empty;
		}

		var permutation = new char[n];
		var counters = new int[AlphabetSize];
		for (int i = 0; i < n; ++i) {
			++counters[s[i] - 'a'];
		}

		int pos = 0;
		for (; pos < n - 1; ++pos) {
			int letterCode = target[pos] - 'a';
			if (counters[letterCode] == 0) {
				break;
			}
			permutation[pos] = (char)(letterCode + 'a');
			--counters[letterCode];
		}

		bool isGreaterPositionFound = false;
		for (; pos >= 0; --pos) {
			for (int letterCode = target[pos] - 'a' + 1; letterCode < AlphabetSize; ++letterCode) {
				if (counters[letterCode] > 0) {
					isGreaterPositionFound = true;
					permutation[pos] = (char)(letterCode + 'a');
					--counters[letterCode];
					break;
				}
			}
			if (isGreaterPositionFound) {
				break;
			}
			if (pos > 0) {
				int previousLetterCode = permutation[pos - 1] - 'a';
				++counters[previousLetterCode];
			}
		}

		if (!isGreaterPositionFound) {
			return string.Empty;
		}

		int freeLetterCode = 0;
		for (int i = pos + 1; i < n; ++i) {
			while (counters[freeLetterCode] == 0) {
				++freeLetterCode;
			}
			permutation[i] = (char)(freeLetterCode + 'a');
			--counters[freeLetterCode];
		}
		return new string(permutation);
	}
}
