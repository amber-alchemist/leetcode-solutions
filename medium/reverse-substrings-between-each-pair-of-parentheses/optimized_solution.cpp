// https://leetcode.com/problems/reverse-substrings-between-each-pair-of-parentheses
// #string #queue #deque
class Solution {
public:
	string reverseParentheses(string src_str) {
		int src_str_length = src_str.length();

		vector<int> bracket_pairs_indices(src_str_length);
		stack<int> opening_brackets_positions_stack;
		for (int i = 0; i < src_str_length; ++i) {
			if (src_str[i] == '(') {
				opening_brackets_positions_stack.push(i);
			}
			else if (src_str[i] == ')') {
				int last_opening_bracket_index = opening_brackets_positions_stack.top();
				opening_brackets_positions_stack.pop();

				bracket_pairs_indices[i] = last_opening_bracket_index;
				bracket_pairs_indices[last_opening_bracket_index] = i;
			}
		}

		string processed_string;
		for (int i = 0, direction = 1; i < src_str_length; i += direction) {
			if (src_str[i] == '(' || src_str[i] == ')') {
				i = bracket_pairs_indices[i];
				direction = -direction;
			}
			else {
				processed_string += src_str[i];
			}
		}
		return processed_string;
	}
};
