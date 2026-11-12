// https://leetcode.com/problems/longest-strictly-increasing-or-strictly-decreasing-subarray
// #array
class Solution {
public:
	int longestMonotonicSubarray(vector<int>& nums) {
		int array_size = nums.size();
		int longest_inc_length = 1, cur_inc_length = 1;
		int longest_dec_length = 1, cur_dec_length = 1;
		for (int i = 1; i < array_size; ++i) {
			if (nums[i - 1] < nums[i]) {
				++cur_inc_length;
			}
			else {
				longest_inc_length = max(longest_inc_length, cur_inc_length);
				cur_inc_length = 1;
			}
			if (nums[i - 1] > nums[i]) {
				++cur_dec_length;
			}
			else {
				longest_dec_length = max(longest_dec_length, cur_dec_length);
				cur_dec_length = 1;
			}
		}
		longest_inc_length = max(longest_inc_length, cur_inc_length);
		longest_dec_length = max(longest_dec_length, cur_dec_length);
		return max(longest_inc_length, longest_dec_length);
	}
};
