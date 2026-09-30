// https://leetcode.com/problems/maximum-nesting-depth-of-two-valid-parentheses-strings
// #sorting #two_pointers
class Solution {
public:
	vector<vector<int>> fourSum(vector<int>& nums, int target) {
		vector<vector<int>> quadruplets;

		sort(nums.begin(), nums.end());

		long long corrected_target = (long long)target;
		int numbers_count = nums.size();
		for (int i = 0; i < numbers_count - 3; ++i) {
			for (int j = i + 1; j < numbers_count - 2; ++j) {
				long long current_target = corrected_target - nums[i] - nums[j];
				int left = j + 1;
				int right = numbers_count - 1;
				while (left < right) {
					if (nums[left] + nums[right] < current_target) {
						++left;
					}
					else if (nums[left] + nums[right] > current_target) {
						--right;
					}
					else {
						quadruplets.push_back({ nums[i], nums[j], nums[left], nums[right] });
						int fixed_left = left;
						while (left < right && nums[fixed_left] == nums[left]) {
							++left;
						}
						int fixed_right = right;
						while (left < right && nums[right] == nums[fixed_right]) {
							--right;
						}
					}
				}
				while (j + 1 < numbers_count && nums[j] == nums[j + 1]) {
					++j;
				}
			}
			while (i + 1 < numbers_count && nums[i] == nums[i + 1]) {
				++i;
			}
		}
		return quadruplets;
	}
};
