// https://leetcode.com/problems/detect-capital
// #string
class Solution {
public:
	bool detectCapitalUse(string word) {
		int length = word.length();
		if (length == 1) {
			return true;
		}
		bool is_first_capital = _isCapitalLetter(word[0]);
		bool is_second_capital = _isCapitalLetter(word[1]);
		if (!is_first_capital && is_second_capital) {
			return false;
		}
		bool is_all_should_be_upper = is_first_capital && is_second_capital;
		for (int i = 2; i < length; ++i) {
			if (_isCapitalLetter(word[i]) != is_all_should_be_upper) {
				return false;
			}
		}
		return true;
	}
private:
	bool _isCapitalLetter(char c)
	{
		return c >= 'A' && c <= 'Z';
	}
};
