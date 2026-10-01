// https://leetcode.com/problems/valid-parentheses
// #stack
class Solution {
public:
	bool isValid(string src_str) {
		if (src_str.size() % 2 != 0) {
			return false;
		}
		stack<char> stack;
		for (char ch : src_str) {
			if (_isOpeningBracket(ch)) {
				stack.push(ch);
			}
			else {
				if (stack.empty() || !_isValidBracketPair(stack.top(), ch)) {
					return false;
				}
				stack.pop();
			}
		}
		return stack.empty();
	}
private:
	bool _isOpeningBracket(char ch) {
		return ch == '(' || ch == '{' || ch == '[';
	}

	bool _isValidBracketPair(char c1, char c2) {
		return c1 == '(' && c2 == ')' || c1 == '{' && c2 == '}' || c1 == '[' && c2 == ']';
	}
};
