// https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string
// #string
public class Solution
{
	public int StrStr(string haystack, string needle)
	{
		int border = haystack.Length - needle.Length;
		for (int i = 0; i <= border; ++i) {
			for (int j = 0; j < needle.Length; ++j) {
				if (haystack[i + j] != needle[j]) {
					break;
				}
				if (j + 1 == needle.Length) {
					return i;
				}
			}
		}
		return -1;
	}
}
