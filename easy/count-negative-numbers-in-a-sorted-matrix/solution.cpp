// https://leetcode.com/problems/count-negative-numbers-in-a-sorted-matrix
// #matrix
class Solution {
public:
	int countNegatives(vector<vector<int>>& grid) {
		int n = grid.size();
		int m = grid[0].size();
		int negatives_count = 0;
		for (int j = m - 1; j >= 0; --j) {
			if (grid[n - 1][j] >= 0) {
				break;
			}
			++negatives_count;
			for (int i = n - 2; i >= 0; --i) {
				if (grid[i][j] >= 0) {
					break;
				}
				++negatives_count;
			}
		}
		return negatives_count;
	}
};
