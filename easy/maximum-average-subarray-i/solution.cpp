// https://leetcode.com/problems/maximum-average-subarray-i
// #sliding_window
class Solution {
public:
	double findMaxAverage(vector<int>& nums, int k) {
		int sum = 0;
		for (int i = 0; i < k; ++i) {
			sum += nums[i];
		}

		int max_sum = sum;
		int n = nums.size();
		for (int l = 0, r = k; r < n; ++l, ++r) {
			sum = sum - nums[l] + nums[r];
			if (sum > max_sum) {
				max_sum = sum;
			}
		}
		return (double)max_sum / k;
	}
};
