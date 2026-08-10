// https://leetcode.com/problems/ransom-note
// #string
public class Solution
{
	public bool CanConstruct(string ransomNote, string magazine)
	{
		const int AlphabetSize = 26;

		var lettersCount = new int[AlphabetSize];
		for (int i = 0; i < magazine.Length; ++i) {
			++lettersCount[magazine[i] - 'a'];
		}
		for (int i = 0; i < ransomNote.Length; ++i) {
			if (lettersCount[ransomNote[i] - 'a'] == 0) {
				return false;
			}
			--lettersCount[ransomNote[i] - 'a'];
		}
		return true;
	}
}
