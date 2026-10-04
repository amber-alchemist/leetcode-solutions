// https://leetcode.com/problems/increasing-triplet-subsequence
// #greedy
class Solution {
public:
	bool increasingTriplet(vector<int>& nums) {
		int n = nums.size();
		if (n < 3) {
			return false;
		}
		int ptr = 1;
		while (ptr < n && nums[ptr - 1] >= nums[ptr]) {
			++ptr;
		}
		if (ptr == n) {
			return false;
		}
		int lower_bound = nums[ptr - 1];
		int upper_bound = nums[ptr];
		while (ptr < n) {
			if (nums[ptr] > upper_bound) {
				return true;
			}
			if (nums[ptr] < lower_bound) {
				lower_bound = nums[ptr];
			}
			else if (nums[ptr] < upper_bound) {
				upper_bound = nums[ptr];
			}
			++ptr;
		}
		return false;
	}
};
