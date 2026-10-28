// https://leetcode.com/problems/decode-string
// #stack #string
class Solution {
public:
	string decodeString(string s) {
		stack<pair<int, string>> stack;
		stack.push({ 1, "" });
		int n = s.length();
		int current_multiplier = 0;
		for (int i = 0; i < n; ++i) {
			if (s[i] >= '0' && s[i] <= '9') {
				current_multiplier = (current_multiplier * 10) + (s[i] - '0');
			}
			else if (s[i] == ']') {
				auto decoding_top_frame = stack.top();
				stack.pop();
				string decoded_part;
				for (int j = 0; j < decoding_top_frame.first; ++j) {
					decoded_part += decoding_top_frame.second;
				}
				stack.top().second += decoded_part;
			}
			else if (s[i] == '[') {
				stack.push({ current_multiplier, "" });
				current_multiplier = 0;
			}
			else {
				stack.top().second += s[i];
			}
		}
		return stack.top().second;
	}
};
