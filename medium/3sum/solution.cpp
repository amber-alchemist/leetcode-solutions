// https://leetcode.com/problems/3sum
// #sorting #two_pointers
class Solution {
public:
	vector<vector<int>> threeSum(vector<int>& nums) {
		vector<vector<int>> triplets;

		sort(nums.begin(), nums.end());

		int nums_count = nums.size();
		for (int i = 0; i < nums_count - 2 && nums[i] <= 0; ++i) {
			if (i > 0 && nums[i - 1] == nums[i]) {
				continue;
			}
			int left = i + 1, right = nums_count - 1;
			while (left < right) {
				int current_sum = nums[i] + nums[left] + nums[right];
				if (current_sum < 0) {
					++left;
				}
				else if (current_sum > 0) {
					--right;
				}
				else {
					triplets.push_back({ nums[i], nums[left++], nums[right--] });
					while (left < right && nums[left - 1] == nums[left]) {
						++left;
					}
					while (left < right && nums[right] == nums[right + 1]) {
						--right;
					}
				}
			}
		}
		return triplets;
	}
};
