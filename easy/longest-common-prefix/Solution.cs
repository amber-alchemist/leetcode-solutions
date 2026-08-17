// https://leetcode.com/problems/longest-common-prefix
// #string
public class Solution
{
	public string LongestCommonPrefix(string[] strs)
	{
		const int MaxStringLength = 200;

		int commonPrefixLength = 0;
		for (int j = 0; j < MaxStringLength; ++j) {
			for (int i = 0; i < strs.Length; ++i) {
				if (j >= strs[i].Length || strs[i][j] != strs[0][j]) {
					return strs[0][..commonPrefixLength];
				}
			}
			++commonPrefixLength;
		}
		return strs[0][..commonPrefixLength];
	}
}
