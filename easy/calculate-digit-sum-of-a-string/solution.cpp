// https://leetcode.com/problems/calculate-digit-sum-of-a-string
// #string
class Solution {
public:
	string digitSum(string s, int k) {
		while (s.length() > k) {
			string s_temp;
			int n = s.length();
			for (int i = 0; i < n; i += k) {
				int sum = 0;
				int m = min(i + k, n);
				for (int j = i; j < m; ++j) {
					sum += s[j] - '0';
				}
				s_temp += to_string(sum);
			}
			s = s_temp;
		}
		return s;
	}
};
