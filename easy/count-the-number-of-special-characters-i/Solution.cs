// https://leetcode.com/problems/count-the-number-of-special-characters-i
// #string
public class Solution
{
	public int NumberOfSpecialChars(string word)
	{
		const int AlphabetLength = 26;

		var lowercaseLetterExist = new bool[AlphabetLength];
		var uppercaseLetterExist = new bool[AlphabetLength];
		for (int i = 0; i < word.Length; ++i) {
			if (char.IsUpper(word[i])) {
				uppercaseLetterExist[word[i] - 'A'] = true;
			}
			else {
				lowercaseLetterExist[word[i] - 'a'] = true;
			}
		}

		int specialCharsCount = 0;
		for (int i = 0; i < AlphabetLength; ++i) {
			if (lowercaseLetterExist[i] && uppercaseLetterExist[i]) {
				++specialCharsCount;
			}
		}
		return specialCharsCount;
	}
}
