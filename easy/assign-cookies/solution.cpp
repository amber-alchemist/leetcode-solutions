// https://leetcode.com/problems/assign-cookies
// #sorting
class Solution {
public:
	int findContentChildren(vector<int>& g, vector<int>& s) {
		int n = g.size(), m = s.size();
		if (m == 0) {
			return 0;
		}
		
		sort(g.begin(), g.end());
		sort(s.begin(), s.end());
		
		int content_children_count = 0;
		for (int i = 0, j = 0; i < n && j < m; ++j) {
			if (g[i] <= s[j]) {
				++content_children_count;
				++i;
			}
		}
		return content_children_count;
	}
};
