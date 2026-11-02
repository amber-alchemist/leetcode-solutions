// https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii
// #math #sorting
class Solution {
public:
	int minMoves2(vector<int>& nums) {
		sort(nums.begin(), nums.end());
		int median_value = nums[nums.size() / 2];
		int min_moves_count = 0;
		for (int number : nums) {
			min_moves_count += abs(median_value - number);
		}
		return min_moves_count;
	}
};
