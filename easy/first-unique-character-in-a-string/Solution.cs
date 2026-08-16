// https://leetcode.com/problems/first-unique-character-in-a-string
// #string
public class Solution
{
	public int FirstUniqChar(string s)
	{
		const int AlphabetSize = 26;

		int first = -1;
		var occurrences = new int[AlphabetSize];
		for (int i = 0; i < s.Length; ++i) {
			int o = ++occurrences[s[i] - 'a'];
			if (o == 1 && first == -1) {
				first = i;
			}
			else if (o > 1 && first != -1 && s[first] == s[i]) {
				int newFirst = -1;
				for (int j = first + 1; j < i; ++j) {
					if (occurrences[s[j] - 'a'] == 1) {
						newFirst = j;
						break;
					}
				}
				first = newFirst;
			}
		}
		return first;
	}
}
