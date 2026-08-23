// https://leetcode.com/problems/number-of-substrings-containing-all-three-characters
// #string
public class Solution
{
	public int NumberOfSubstrings(string s)
	{
		int substringsNumber = 0;
		int lastPosA = -1, lastPosB = -1, lastPosC = -1;
		for (int i = 0; i < s.Length; ++i) {
			if (s[i] == 'a') {
				lastPosA = i;
			} else if (s[i] == 'b') {
				lastPosB = i;
			} else if (s[i] == 'c') {
				lastPosC = i;
			}
			int earliest = Math.Min(lastPosA, Math.Min(lastPosB, lastPosC));
			substringsNumber += earliest + 1;
		}
		return substringsNumber;
	}
}
