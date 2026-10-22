// https://leetcode.com/problems/minimum-operations-to-sort-a-string
// #string
class Solution {
public:
	int minOperations(string s) {
		int n = s.length();
		if (n == 1) {
			return 0;
		}
		else if (n == 2) {
			return s[0] <= s[1] ? 0 : -1;
		}

		bool is_sorted = true;
		char min_letter = s[0];
		char max_letter = s[0];
		for (int i = 1; i < n; ++i) {
			if (s[i] < min_letter) {
				min_letter = s[i];
			}
			if (s[i] > max_letter) {
				max_letter = s[i];
			}
			if (s[i - 1] > s[i]) {
				is_sorted = false;
			}
		}
		if (is_sorted) {
			return 0;
		}
		else if (s[0] == min_letter || s[n - 1] == max_letter) {
			return 1;
		}
		for (int i = 1; i < n - 1; ++i) {
			if (s[i] == min_letter || s[i] == max_letter) {
				return 2;
			}
		}
		return 3;
	}
};
