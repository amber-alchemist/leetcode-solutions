// https://leetcode.com/problems/minimum-number-of-changes-to-make-binary-string-beautiful
// #greedy_algorithm
class Solution {
public:
	int minChanges(string s) {
		int n = s.size();
		int min_changes = 0;
		for (int i = 0; i < n; i += 2) {
			if (s[i] != s[i + 1]) {
				++min_changes;
			}
		}
		return min_changes;
	}
};
