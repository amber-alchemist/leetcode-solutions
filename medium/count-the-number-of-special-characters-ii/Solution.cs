// https://leetcode.com/problems/count-the-number-of-special-characters-ii
// #string
public class Solution
{
	private enum SpecialCharSearchState
	{
		None,
		LowercaseExist,
		SpecialChar,
		Invalid,
	}

	public int NumberOfSpecialChars(string word)
	{
		const int AlphabetLength = 26;

		var searchStates = new SpecialCharSearchState[AlphabetLength];
		for (int i = 0; i < word.Length; ++i) {
			if (char.IsUpper(word[i])) {
				int j = char.ToLower(word[i]) - 'a';
				var currentState = searchStates[j];
				if (currentState == SpecialCharSearchState.None) {
					searchStates[j] = SpecialCharSearchState.Invalid;
				}
				else if (currentState == SpecialCharSearchState.LowercaseExist) {
					searchStates[j] = SpecialCharSearchState.SpecialChar;
				}
			}
			else {
				int j = word[i] - 'a';
				var currentState = searchStates[j];
				if (currentState == SpecialCharSearchState.None) {
					searchStates[j] = SpecialCharSearchState.LowercaseExist;
				}
				else if (currentState == SpecialCharSearchState.SpecialChar) {
					searchStates[j] = SpecialCharSearchState.Invalid;
				}
			}
		}

		int specialCharsCount = 0;
		for (int i = 0; i < AlphabetLength; ++i) {
			if (searchStates[i] == SpecialCharSearchState.SpecialChar) {
				++specialCharsCount;
			}
		}
		return specialCharsCount;
	}
}
