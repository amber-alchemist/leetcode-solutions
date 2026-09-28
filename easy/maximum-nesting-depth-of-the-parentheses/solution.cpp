// https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses
// #string
class Solution {
public:
	int maxDepth(string src_str) {
		int max_brackets_nesting_depth = 0;
		int current_opening_brackets_count = 0;
		for (char ch : src_str) {
			if (ch == '(') {
				if (++current_opening_brackets_count > max_brackets_nesting_depth) {
					max_brackets_nesting_depth = current_opening_brackets_count;
				}
			}
			else if (ch == ')') {
				--current_opening_brackets_count;
			}
		}
		return max_brackets_nesting_depth;
	}
};
