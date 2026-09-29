// https://leetcode.com/problems/move-zeroes
// #two_pointers
class Solution {
public:
	void moveZeroes(vector<int>& nums) {
		int n = nums.size();
		for (int left = 0, right = 1; right < n; ++right) {
			if (nums[right] == 0) {
				continue;
			}
			while (left < right && nums[left] != 0) {
				++left;
			}
			if (left < right) {
				swap(nums[left], nums[right]);
			}
		}
	}
};
