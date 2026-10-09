// https://leetcode.com/problems/longest-valid-parentheses
// #string #two_pointers
class Solution {
public:
	int longestValidParentheses(string str) {
		int n = str.length();
		int max_length = 0;
		int last_excluded_start = -1;
		int open_brackets_count = 0;
		for (int i = 0; i < n; ++i) {
			if (str[i] == '(') {
				++open_brackets_count;
			}
			else if (str[i] == ')') {
				if (open_brackets_count > 0) {
					--open_brackets_count;
				}
				else {
					int current_length = i - 1 - last_excluded_start;
					if (current_length > max_length) {
						max_length = current_length;
					}
					last_excluded_start = i;
					open_brackets_count = 0;
				}
			}
		}
		
		if (open_brackets_count > 0) {
			int last_excluded_end = n;
			int close_brackets_count = 0;
			for (int i = n - 1; i > last_excluded_start; --i) {
				if (str[i] == ')') {
					++close_brackets_count;
				}
				else if (str[i] == '(') {
					if (close_brackets_count > 0) {
						--close_brackets_count;
					}
					else {
						int current_length = last_excluded_end - i - 1;
						if (current_length > max_length) {
							max_length = current_length;
						}
						last_excluded_end = i;
						close_brackets_count = 0;
					}
				}
			}
			int current_length = last_excluded_end - last_excluded_start - 1;
			if (current_length > max_length) {
				max_length = current_length;
			}
		}
		else {
			int current_length = n - 1 - last_excluded_start;
			if (current_length > max_length) {
				max_length = current_length;
			}
		}
		return max_length;
	}
};
