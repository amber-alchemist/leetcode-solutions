// https://leetcode.com/problems/longest-palindromic-substring
// #dynamic_programming
public class Solution
{
	public string LongestPalindrome(string str)
	{
		int length = str.Length;

		bool[,] dp = new bool[length, length];
		for (int i = 0; i < length; ++i) {
			dp[i, i] = true;
		}

		(int start, int length) answer = (0, 1);
		for (int i = 0; i < length - 1; ++i) {
			dp[i, i + 1] = str[i] == str[i + 1];
			if (dp[i, i + 1]) {
				answer = (i, 2);
			}
		}

		for (int k = 2; k < length; ++k) {
			int border = length - k;
			for (int i = 0; i < border; ++i) {
				int j = i + k;
				if (str[i] == str[j] && dp[i + 1, j - 1]) {
					dp[i, j] = true;
					answer = (i, k + 1);
				}
			}
		}

		return str.Substring(answer.start, answer.length);
	}
}
