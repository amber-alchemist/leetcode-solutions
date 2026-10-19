// https://leetcode.com/problems/find-target-indices-after-sorting-array
// #sorting
class Solution {
public:
	vector<int> targetIndices(vector<int>& nums, int target) {
		vector<int> target_indices;
		sort(nums.begin(), nums.end());
		int n = nums.size();
		for (int i = 0; i < n; ++i) {
			if (nums[i] == target) {
				target_indices.push_back(i);
			}
		}
		return target_indices;
	}
};
