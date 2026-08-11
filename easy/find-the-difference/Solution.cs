// https://leetcode.com/problems/find-the-difference
// #string
public class Solution
{
	public char FindTheDifference(string s, string t)
	{
		var frequencies = new int[26];
		for (int i = 0; i < t.Length; ++i) {
			++frequencies[t[i] - 'a'];
		}
		for (int i = 0; i < s.Length; ++i) {
			--frequencies[s[i] - 'a'];
		}
		for (int i = 0; i < frequencies.Length; ++i) {
			if (frequencies[i] > 0) {
				return (char)(i + 'a');
			}
		}
		throw new InvalidOperationException();
	}
}
