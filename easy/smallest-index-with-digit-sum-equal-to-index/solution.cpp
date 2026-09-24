// https://leetcode.com/problems/smallest-index-with-digit-sum-equal-to-index
// #math
class Solution {
public:
	int smallestIndex(vector<int>& nums) {
		int n = nums.size();
		for (int i = 0; i < n; ++i) {
			int digits_sum = 0;
			while (nums[i] > 0) {
				int digit = nums[i] % 10;
				digits_sum += digit;
				nums[i] /= 10;
			}
			if (digits_sum == i) {
				return i;
			}
		}
		return -1;
	}
};
