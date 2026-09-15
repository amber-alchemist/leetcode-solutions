// https://leetcode.com/problems/di-string-match
// #greedy_algorithm
class Solution {
public:
	vector<int> diStringMatch(string s) {
		int n = s.size();
		int min_number = 0, max_number = n;
		vector<int> reconstructed_permutation(n + 1);
		for (int i = 0; i < n; ++i) {
			reconstructed_permutation[i] = s[i] == 'I' ? min_number++ : max_number--;
		}
		reconstructed_permutation[n] = max_number;
		return reconstructed_permutation;
	}
};
