// https://leetcode.com/problems/smallest-stable-index-i
// #suffix_min #array
class Solution {
public:
	int firstStableIndex(vector<int>& nums, int k) {
		int n = nums.size();

		int* suffix_min = new int[n];
		suffix_min[n - 1] = nums[n - 1];
		for (int i = n - 2; i >= 0; --i) {
			suffix_min[i] = nums[i] < suffix_min[i + 1] ? nums[i] : suffix_min[i + 1];
		}

		int min_stable_index = -1;
		int max = -1;
		for (int i = 0; i < n; ++i) {
			if (nums[i] > max) {
				max = nums[i];
			}
			bool is_stable_index = max - suffix_min[i] <= k;
			if (is_stable_index) {
				min_stable_index = i;
				break;
			}
		}

		delete[] suffix_min;
		return min_stable_index;
	}
};
