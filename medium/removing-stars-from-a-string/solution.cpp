// https://leetcode.com/problems/removing-stars-from-a-string
// #stack
class Solution {
public:
	string removeStars(string src_str) {
		char* buffer = new char[src_str.length()];
		int end_ptr = 0;
		for (char ch : src_str) {
			if (ch == '*') {
				--end_ptr;
			}
			else {
				buffer[end_ptr++] = ch;
			}
		}
		return string(buffer, end_ptr);
	}
};
