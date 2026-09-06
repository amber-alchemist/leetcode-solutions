// https://leetcode.com/problems/distinct-subsequences
// #string #dynamic_programming
public class Solution
{
	public int NumDistinct(string s, string t)
	{
		int n = s.Length, m = t.Length;
		if (m > n) {
			return 0;
		}

		var dp = new int[m + 1];
		dp[0] = 1;
		for (int i = 0; i < n; ++i) {
			for (int j = m - 1; j >= 0; --j) {
				if (s[i] == t[j]) {
					dp[j + 1] += dp[j];
				}
			}
		}
		return dp[m];
	}
}
