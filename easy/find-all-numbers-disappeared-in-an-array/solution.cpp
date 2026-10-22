// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array
// #array
class Solution {
public:
	vector<int> findDisappearedNumbers(vector<int>& nums) {
		int n = nums.size();
		for (int i = 0; i < n; ++i) {
			int index = abs(nums[i]) - 1;
			if (nums[index] > 0) {
				nums[index] = -nums[index];
			}
		}

		vector<int> disappeared_numbers;
		disappeared_numbers.reserve(n - 1);
		for (int i = 0; i < n; ++i) {
			if (nums[i] > 0) {
				disappeared_numbers.push_back(i + 1);
			}
		}
		return  disappeared_numbers;
	}
};
