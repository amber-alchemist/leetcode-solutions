// https://leetcode.com/problems/is-subsequence
// #two_pointers
class Solution {
public:
	bool isSubsequence(string s, string t) {
		int m = s.length();
		int n = t.length();
		if (m > n) {
			return false;
		}
		int k = 0;
		for (int i = 0; i < n && k < m; ++i) {
			if (s[k] == t[i]) {
				++k;
			}
		}
		return k == m;
	}
};
