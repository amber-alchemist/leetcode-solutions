// https://leetcode.com/problems/minimum-add-to-make-parentheses-valid
// #stack #greedy_algorithm
class Solution {
public:
	int minAddToMakeValid(string s) {
		int operations_count = 0;
		int open_brackets_count = 0;
		for (char ch : s) {
			if (ch == '(') {
				++open_brackets_count;
			}
			else {
				if (open_brackets_count == 0) {
					++operations_count;
				}
				else {
					--open_brackets_count;
				}
			}
		}
		operations_count += open_brackets_count;
		return operations_count;
	}
};
