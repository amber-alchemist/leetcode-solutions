// https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element
// #sliding_window
class Solution {
public:
	int longestSubarray(vector<int>& nums) {
		int n = nums.size();
		int last_zero_pos = 0;
		while (last_zero_pos < n && nums[last_zero_pos] == 1) {
			++last_zero_pos;
		}
		if (last_zero_pos == n) {
			return n - 1;
		}

		int m = n - 1;
		int last_segment_length = last_zero_pos;
		int max_length = last_segment_length;
		for (int i = last_zero_pos + 1; i < m; ++i) {
			if (nums[i] == 0) {
				int current_segment_length = i - last_zero_pos - 1;
				max_length = max(max_length, last_segment_length + current_segment_length);
				last_segment_length = current_segment_length;
				last_zero_pos = i;
			}
		}
		int current_segment_length = m - last_zero_pos - 1 + nums[m];
		max_length = max(max_length, last_segment_length + current_segment_length);
		return max_length;
	}
};
