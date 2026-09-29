// https://leetcode.com/problems/reverse-words-in-a-string
// #string
class Solution {
public:
	string reverseWords(string src_str) {
		string result_str;
		result_str.reserve(src_str.length());
		bool is_first_word_met = false;
		int ptr = src_str.length() - 1;
		while (ptr >= 0) {
			while (ptr >= 0 && src_str[ptr] == ' ') {
				--ptr;
			}
			if (ptr < 0) {
				break;
			}
			int word_end_ptr = ptr--;
			while (ptr >= 0 && src_str[ptr] != ' ') {
				--ptr;
			}
			if (is_first_word_met) {
				result_str += " ";
			}
			else {
				is_first_word_met = true;
			}
			int word_length = word_end_ptr - ptr;
			result_str += src_str.substr(ptr + 1, word_length);
		}
		return result_str;
	}
};
