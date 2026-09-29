// https://leetcode.com/problems/reverse-vowels-of-a-string
// #string
class Solution {
public:
	string reverseVowels(string src_str) {
		int length = src_str.length();
		string result_str;
		result_str.resize(length);
		for (int left = 0, right = length - 1; left < length; ++left) {
			if (_isVowel(src_str[left])) {
				for (; left < right; --right) {
					if (_isVowel(src_str[right])) {
						swap(src_str[left], src_str[right]);
						--right;
						break;
					}
				}
			}
			result_str[left] = src_str[left];
		}
		return result_str;
	}
private:
	bool _isVowel(char c) {
		return
			c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' ||
			c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
	}
};
