// https://leetcode.com/problems/to-lower-case
// #string
public class Solution
{
	public string ToLowerCase(string s)
	{
		var newChars = new char[s.Length];
		for (int i = 0; i < s.Length; ++i) {
			if (s[i] >= 'A' && s[i] <= 'Z') {
				int diff = s[i] - 'A';
				newChars[i] = (char)('a' + diff);
			}
			else {
				newChars[i] = s[i];
			}
		}
		return new string(newChars);
	}
}
