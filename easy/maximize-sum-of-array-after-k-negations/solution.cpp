// https://leetcode.com/problems/maximize-sum-of-array-after-k-negations
// #math #sorting
class Solution {
public:
	int largestSumAfterKNegations(vector<int>& nums, int k) {
		sort(nums.begin(), nums.end());
		int largest_sum = 0;
		int min_absolute_value = 1000;
		for (int i = 0; i < nums.size(); ++i) {
			if (nums[i] < 0 && k > 0) {
				nums[i] = -nums[i];
				--k;
			}
			largest_sum += nums[i];
			min_absolute_value = min(abs(nums[i]), min_absolute_value);
		}
		if (k % 2 == 1) {
			largest_sum -= 2 * min_absolute_value;
		}
		return largest_sum;
	}
};
