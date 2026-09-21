// https://leetcode.com/problems/reverse-degree-of-a-string
// #hash_map
class Solution {
public:
	vector<string> findRelativeRanks(vector<int>& score) {
		int n = score.size();

		map<int, int> sorted_ranks;
		for (int i = 0; i < n; ++i) {
			sorted_ranks[score[i]] = i;
		}

		vector<string> relative_ranks(n);
		auto it = sorted_ranks.begin();
		for (int i = n - 1; i > 2; --i) {
			relative_ranks[(it++)->second] = to_string(i + 1);
		}
		if (n > 2) {
			relative_ranks[(it++)->second] = "Bronze Medal";
		}
		if (n > 1) {
			relative_ranks[(it++)->second] = "Silver Medal";
		}
		relative_ranks[it->second] = "Gold Medal";
		return relative_ranks;
	}
};
