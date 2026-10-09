// https://leetcode.com/problems/minimum-insertions-to-balance-a-parentheses-string
// #string
class Solution {
public:
	int minInsertions(string str) {
		int n = str.length();
		int insertions_count = 0;
		int close_brackets_pairs_count = 0;
		int ptr = n - 1;
		for (; ptr > 0; --ptr) {
			if (str[ptr] == ')') {
				if (str[ptr - 1] == ')') {
					++close_brackets_pairs_count;
				}
				else if (str[ptr - 1] == '(') {
					++insertions_count;
				}
				--ptr;
			}
			else if (str[ptr] == '(') {
				if (close_brackets_pairs_count == 0) {
					insertions_count += 2;
				}
				else {
					--close_brackets_pairs_count;
				}
			}
		}

		if (ptr == 0) {
			if (str[ptr] == ')') {
				insertions_count += 2;
			}
			else if (str[ptr] == '(') {
				if (close_brackets_pairs_count == 0) {
					insertions_count += 2;
				}
				else {
					--close_brackets_pairs_count;
				}
			}
		}

		insertions_count += close_brackets_pairs_count;
		return insertions_count;
	}
};
