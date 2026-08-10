// https://leetcode.com/problems/reverse-string
// #string
public class Solution
{
	public void ReverseString(char[] s)
	{
		int pairsCount = s.Length / 2;
		for (int i = 0; i < pairsCount; ++i) {
			(s[i], s[^(1 + i)]) = (s[^(1 + i)], s[i]);
		}
	}
}
