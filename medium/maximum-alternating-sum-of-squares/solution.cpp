// https://leetcode.com/problems/maximum-alternating-sum-of-squares
// #sorting #greedy_algorithm
class Solution {
public:
	long long maxAlternatingSum(vector<int>& nums) {
		int n = nums.size();
		for (int i = 0; i < n; ++i) {
			nums[i] *= nums[i];
		}
		sort(nums.begin(), nums.end());

		long long max_alternating_sum = 0ll;
		for (int i = 0, j = n - 1; i < j; ++i, --j) {
			max_alternating_sum += (long long)(nums[j] - nums[i]);
		}
		if (n % 2 == 1) {
			max_alternating_sum += (long long)nums[n / 2];
		}
		return max_alternating_sum;
	}
};
