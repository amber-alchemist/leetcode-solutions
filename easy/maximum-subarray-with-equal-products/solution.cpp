// https://leetcode.com/problems/maximum-subarray-with-equal-products
// #number_theory #sliding_window
class Solution {
public:
	int maxLength(vector<int>& nums) {
		int n = nums.size();
		int prod = nums[0];
		int max_length = 2;
		for (int l = 0, r = 1; r < n; ++r) {
			while (gcd(prod, nums[r]) > 1) {
				prod /= nums[l++];
			}
			prod *= nums[r];
			max_length = max(max_length, r - l + 1);
		}
		return max_length;
	}
};
