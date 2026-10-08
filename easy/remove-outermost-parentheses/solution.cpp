// https://leetcode.com/problems/remove-outermost-parentheses
// #string
class Solution {
public:
	string removeOuterParentheses(string src_str) {
		string proccesed_str;
		proccesed_str.reserve(src_str.length());
		int depth = 0;
		for (char ch : src_str) {
			if (ch == '(') {
				if (depth++ > 0) {
					proccesed_str.push_back('(');
				}
			}
			else if (ch == ')') {
				if (--depth > 0) {
					proccesed_str.push_back(')');
				}
			}
		}
		return proccesed_str;
	}
};
