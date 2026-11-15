// https://leetcode.com/problems/height-checker
// #sorting
class Solution {
public:
	int heightChecker(vector<int>& heights) {
		vector<int> expected(heights);
		sort(expected.begin(), expected.end());

		int n = heights.size();
		int unmatched_heights_count = 0;
		for (int i = 0; i < n; ++i) {
			if (heights[i] != expected[i]) {
				++unmatched_heights_count;
			}
		}
		return unmatched_heights_count;
	}
};
