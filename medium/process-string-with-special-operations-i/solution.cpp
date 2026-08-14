// https://leetcode.com/problems/process-string-with-special-operations-i
// #string
class Solution {
public:
	string processStr(string str) {
		string processed_str = "";
		for (int i = 0; i < str.length(); ++i) {
			if (str[i] == '*') {
				if (!processed_str.empty()) {
					processed_str.pop_back();
				}
			}
			else if (str[i] == '#') {
				processed_str += processed_str;
			}
			else if (str[i] == '%') {
				reverse(processed_str.begin(), processed_str.end());
			}
			else {
				processed_str += str[i];
			}
		}
		return processed_str;
	}
};
