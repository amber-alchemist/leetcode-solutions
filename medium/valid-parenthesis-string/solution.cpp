// https://leetcode.com/problems/valid-parenthesis-string
// #two_pointers #greedy
class Solution {
public:
	bool checkValidString(string s) {
		int length = s.length();
		int open_brackets_count = 0;
		int close_brackets_count = 0;
		for (int i = 0, j = length - 1; i < length; ++i, --j) {
			open_brackets_count += s[i] == '(' || s[i] == '*' ? 1 : -1;
			if (open_brackets_count < 0) {
				return false;
			}

			close_brackets_count += s[j] == ')' || s[j] == '*' ? 1 : -1;
			if (close_brackets_count < 0) {
				return false;
			}
		}
		return true;
	}
};
