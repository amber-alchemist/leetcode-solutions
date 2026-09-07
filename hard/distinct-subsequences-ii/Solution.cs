// https://leetcode.com/problems/distinct-subsequences-ii
// #dynamic_programming #string
public class Solution
{
	public int DistinctSubseqII(string s)
	{
		const int AlphabetSize = 26;
		const int Modulo = 1_000_000_007;

		int n = s.Length;
		if (n == 1) {
			return 1;
		}

		int distinctSubsequences = 0;
		var countsOfSubsequencesStartedAtLetter = new int[AlphabetSize];
		for (int i = n - 1; i >= 0; --i) {
			int letterCode = s[i] - 'a';
			int added = (distinctSubsequences + 1 + Modulo - countsOfSubsequencesStartedAtLetter[letterCode]) % Modulo;
			countsOfSubsequencesStartedAtLetter[letterCode] = (countsOfSubsequencesStartedAtLetter[letterCode] + added) % Modulo;
			distinctSubsequences = (distinctSubsequences + added) % Modulo;
		}
		return distinctSubsequences;
	}
}
