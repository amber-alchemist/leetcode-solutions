// https://leetcode.com/problems/max-number-of-k-sum-pairs
// #sorting #two_pointrts
class Solution {
public:
	int maxOperations(vector<int>& nums, int k) {
		sort(nums.begin(), nums.end());

		int n = nums.size();
		int left = 0;
		int right = n - 1;
		int max_operations = 0;

		while (left < right && nums[left] < k) {
			int sum = nums[left] + nums[right];
			if (sum == k) {
				++max_operations;
				++left;
				--right;
			}
			else if (sum < k) {
				++left;
			}
			else {
				--right;
			}
		}
		return max_operations;
	}
};
