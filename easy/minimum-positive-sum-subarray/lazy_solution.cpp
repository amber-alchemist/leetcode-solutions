// https://leetcode.com/problems/minimum-positive-sum-subarray
// #prefix_sum
class Solution {
public:
	int minimumSumSubarray(vector<int>& nums, int l, int r) {
		int n = nums.size();
		vector<int> prefix_sum(n + 1, 0);
		for (int i = 0; i < n; ++i) {
			prefix_sum[i + 1] = prefix_sum[i] + nums[i];
		}

		bool found = false;
		int min_sum_subarray = INT_MAX;
		for (int i = 0; i < n; ++i) {
			for (int j = l; j <= r; ++j) {
				int k = i + j;
				if (k > n) {
					break;
				}
				int sum_subarray = prefix_sum[k] - prefix_sum[i];
				if (sum_subarray > 0) {
					found = true;
					min_sum_subarray = min(min_sum_subarray, sum_subarray);
				}
			}
		}
		return found ? min_sum_subarray : -1;
	}
};
