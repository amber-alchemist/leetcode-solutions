// https://leetcode.com/problems/score-of-parentheses
// #string #stack
class Solution {
public:
	int scoreOfParentheses(string s) {
		int length = s.length();
		vector<int> stack;
		int top_stack_ptr = 0;
		int total_score = 0;
		for (int i = 0; i < length; ++i) {
			if (s[i] == '(') {
				if (++top_stack_ptr > stack.size()) {
					stack.push_back(0);
				}
				else {
					stack[top_stack_ptr - 1] = 0;
				}
			}
			else {
				int inner_score = stack[--top_stack_ptr];
				inner_score = inner_score == 0 ? 1 : inner_score * 2;
				if (top_stack_ptr == 0) {
					total_score += inner_score;
				}
				else {
					stack[top_stack_ptr - 1] += inner_score;
				}
			}
		}
		return total_score;
	}
};
