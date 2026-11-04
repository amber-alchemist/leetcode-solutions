// https://leetcode.com/problems/max-consecutive-ones
// #array
class Solution {
public:
	int findMaxConsecutiveOnes(vector<int>& nums) {
		int max_consecutive_ones_count = 0;
		int consecutive_ones_count = 0;
		for (int x : nums) {
			if (x == 1) {
				++consecutive_ones_count;
			}
			else if (consecutive_ones_count > 0) {
				max_consecutive_ones_count = max(max_consecutive_ones_count, consecutive_ones_count);
				consecutive_ones_count = 0;
			}
		}
		return max(max_consecutive_ones_count, consecutive_ones_count);
	}
};
