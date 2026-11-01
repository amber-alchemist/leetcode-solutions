// https://leetcode.com/problems/minimum-moves-to-equal-array-elements
// #array #math
class Solution {
public:
	int minMoves(vector<int>& nums) {
		int n = nums.size();
		int min_number = nums[0];
		for (int i = 1; i < n; ++i) {
			if (nums[i] < min_number) {
				min_number = nums[i];
			}
		}
		int min_moves_count = 0;
		for (int i = 0; i < n; ++i) {
			min_moves_count += nums[i] - min_number;
		}
		return min_moves_count;
	}
};
