// https://leetcode.com/problems/check-if-all-as-appears-before-all-bs
// #string
class Solution {
public:
	bool checkString(string s) {
		bool is_b_present = false;
		for (char letter : s) {
			if (letter == 'a' && is_b_present) {
				return false;
			}
			else if (letter == 'b' && !is_b_present) {
				is_b_present = true;
			}
		}
		return true;
	}
};
