// https://leetcode.com/problems/remove-invalid-parentheses
// #bitwise_operations #combinatorics
class Solution {
public:
	using removing_code = bitset<32>;

	vector<string> removeInvalidParentheses(string s) {
		int n = s.length();

		unordered_set<removing_code> removing_codes = { removing_code{} };

		int open_brackets_count = 0;
		for (int i = 0; i < n; ++i) {
			if (s[i] == '(') {
				++open_brackets_count;
			}
			else if (s[i] == ')') {
				if (open_brackets_count > 0) {
					--open_brackets_count;
				}
				else {
					unordered_set<removing_code> new_removing_codes;
					for (const removing_code& code : removing_codes) {
						for (int j = 0; j <= i; ++j) {
							if (s[j] != ')' || code.test(j)) {
								continue;
							}
							removing_code new_code = code;
							new_code.set(j);
							new_removing_codes.insert(new_code);
						}
					}
					removing_codes.swap(new_removing_codes);
				}
			}
		}
		if (open_brackets_count > 0) {
			int close_brackets_count = 0;
			for (int i = n - 1; i >= 0; --i) {
				if (s[i] == ')') {
					++close_brackets_count;
				}
				else if (s[i] == '(') {
					if (close_brackets_count > 0) {
						--close_brackets_count;
					}
					else {
						unordered_set<removing_code> new_removing_codes;
						for (const removing_code& code : removing_codes) {
							for (int j = n - 1; j >= i; --j) {
								if (s[j] != '(' || code.test(j)) {
									continue;
								}
								removing_code new_code = code;
								new_code.set(j);
								new_removing_codes.insert(new_code);
							}
						}
						removing_codes.swap(new_removing_codes);
					}
				}
			}
		}

		unordered_set<string> unique_valid_parentheses;
		for (const removing_code& code : removing_codes) {
			string candidate;
			for (int i = 0; i < n; ++i) {
				if (!code.test(i)) {
					candidate.push_back(s[i]);
				}
			}
			unique_valid_parentheses.insert(candidate);
		}

		vector<string> valid_parentheses;
		for (const string& candidate : unique_valid_parentheses) {
			valid_parentheses.push_back(candidate);
		}
		return valid_parentheses;
	}
};
