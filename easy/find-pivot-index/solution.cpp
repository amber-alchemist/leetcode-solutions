// https://leetcode.com/problems/find-pivot-index
// #prefix_sum #suffix_sum
class Solution {
public:
	int pivotIndex(vector<int>& nums) {
		int n = nums.size();
		int suffix_sum = 0;
		for (int i = 0; i < n; ++i) {
			suffix_sum += nums[i];
		}

		int prefix_sum = 0;
		for (int i = 0; i < n; ++i) {
			suffix_sum -= nums[i];
			if (prefix_sum == suffix_sum) {
				return i;
			}
			prefix_sum += nums[i];
		}
		return -1;
	}
};
