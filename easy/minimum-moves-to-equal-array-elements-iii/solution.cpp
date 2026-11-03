// https://leetcode.com/problems/minimum-moves-to-equal-array-elements-iii
// #array
class Solution {
public:
	int minMoves(vector<int>& nums) {
		int max_number = INT_MIN;
		for (int x : nums) {
			max_number = max(max_number, x);
		}
		int min_moves_count = 0;
		for (int x : nums) {
			min_moves_count += max_number - x;
		}
		return min_moves_count;
	}
};
