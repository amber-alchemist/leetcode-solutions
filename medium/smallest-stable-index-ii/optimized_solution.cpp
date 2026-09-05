// https://leetcode.com/problems/smallest-stable-index-i
// #suffix_min #array
class Solution {
public:
	int firstStableIndex(vector<int>& nums, int k) {
		int first_stable_index = -1;
		int corresponding_max_value_for_first_stable_index = -1;
		int current_max_value = -1;
		for (int i = 0; i < nums.size(); ++i) {
			if (nums[i] > current_max_value) {
				current_max_value = nums[i];
			}
			if (first_stable_index == -1) {
				bool is_stable_index = current_max_value - nums[i] <= k;
				if (is_stable_index) {
					first_stable_index = i;
					corresponding_max_value_for_first_stable_index = current_max_value;
				}
			}
			else {
				bool is_candidate_still_stable =
					corresponding_max_value_for_first_stable_index - nums[i] <= k;
				if (!is_candidate_still_stable) {
					first_stable_index = -1;
				}
			}
		}
		return first_stable_index;
	}
};
