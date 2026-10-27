// https://leetcode.com/problems/equal-row-and-column-pairs
// #hash_table
class Solution {
public:
	int equalPairs(vector<vector<int>>& grid) {
		map<vector<int>, int> different_rows;

		int n = grid.size();
		for (int i = 0; i < n; ++i) {
			++different_rows[grid[i]];
		}

		int equal_pairs_count = 0;
		vector<int> column(n);
		for (int j = 0; j < n; ++j) {
			for (int i = 0; i < n; ++i) {
				column[i] = grid[i][j];
			}
			equal_pairs_count += different_rows[column];
		}
		return equal_pairs_count;
	}
};
