// https://leetcode.com/problems/length-of-last-word
// #string
public class Solution
{
	public int LengthOfLastWord(string str)
	{
		int wordEnd = str.Length - 1;
		for (; wordEnd >= 0; --wordEnd) {
			if (str[wordEnd] != ' ') {
				break;
			}
		}
		int wordStart = wordEnd;
		for (; wordStart >= 0; --wordStart) {
			if (str[wordStart] == ' ') {
				break;
			}
		}
		return wordEnd - wordStart;
	}
}
