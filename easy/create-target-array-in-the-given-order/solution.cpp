// https://leetcode.com/problems/create-target-array-in-the-given-order
// #array
class Solution {
public:
	vector<int> createTargetArray(vector<int>& nums, vector<int>& index) {
		int n = nums.size();
		vector<int> target_array;
		target_array.reserve(n);

		for (int i = 0; i < n; ++i) {
			if (index[i] >= i) {
				target_array.push_back(nums[i]);
			}
			else {
				target_array.insert(target_array.begin() + index[i], nums[i]);
			}
		}
		return target_array;
	}
};
